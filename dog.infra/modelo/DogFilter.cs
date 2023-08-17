using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dog.infra.modelo
{
    public class DogFilter
    {
        public DogFilter() { filtroLimit = 1; }

        public DogFilter(float _limit)
        {
            int result  = 0;
            if(_limit < 0 && int.TryParse(_limit.ToString(), out result))
                filtroLimit = int.Parse(_limit.ToString());
        }
        public int filtroLimit { get; set; }
    }
}
