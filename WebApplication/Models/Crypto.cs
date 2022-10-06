using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Crypto
    {
        //опис атрибутів моделі Crypto
        public int Id { get; set; }//ідентифікатор доступу
        public string name { get; set; }//ім'я валюти
        public string iName { get; set; }//абревіатурна назва валюти
        public double currency { get; set; }//вартість валюти
        public double changes { get; set; }//зміна вартості валюти (у відсотках)

    }
}