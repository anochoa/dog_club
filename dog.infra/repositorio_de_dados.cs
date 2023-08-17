using dog.infra.modelo;
using RestSharp;

using MySql.Data.MySqlClient;

namespace dog.infra
{
    public class repositorio_de_dados
    {
        public Cachorro[] GetDOGS(DogFilter filter, int itens)
        {
            var doguinhos = new List<Cachorro>();
            
            Thread.Sleep(Utils.EvitandoThrottlingExceptionDaAPI+itens);
            
            var client = new RestClient("https://api.thedogapi.com/");

            var request = new RestRequest($"v1/images/search?limit={filter.filtroLimit}")
                .AddHeader("x-api-key", "live_XkJhgtoqBRSj2LEgpST5FVL3sXTZ6OrsmFKQPUn9FGLV4OSIhd7MxwGjaB07MHi9");

            doguinhos = client.Get<List<Cachorro>>(request)?.ConfigList();

            return doguinhos.ToArray();
        }

        /*
        AQUI TEM UM CONTAINER PRONTO COM O MYSQL
        
        # Pull da imagem:
        docker pull docker.io/library/mysql:5.7

        # Run da imagem
        docker run --name some-mysql -p 3366:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:5.7
        
        Dai só acessar e excutar o comando abaixo para criar o schemma e a tabela: 
        
            create schema thedog collate utf8mb4_general_ci;
            create table osDog
            (
                id     varchar(255)  null,
                url    VARCHAR(4000) null,
                width  numeric       null,
                height int           null
            );

        */
        public bool SaveTheDog(Cachorro dog)
        {

            string sqlToInsert = $@"insert into osDog (id, url, width, height) values ('{dog.id}','{dog.url}',{dog.width},{dog.height});";
            GenericSave(sqlToInsert);

            return true;
        }

        public void GenericSave(string query)
        {
            string connectionString = "Host=localhost;Port=3366;user=root;database=thedog;password=my-secret-pw;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected}");
                    }

                }
            }
            catch { }

        }

    }
}
