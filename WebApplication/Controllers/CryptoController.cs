using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    //Реалізація контролера CryptoController
    public class CryptoController : ApiController
    {
        //Створення колекції з об'єктів (дані +- 22 вересня)
        List<Crypto> _cryptoList = new List<Crypto>
        {
            new Crypto{Id = 1, name = "Ethereum", iName = "ETH", currency = 1344.78, changes = 3.8248},
            new Crypto{Id = 2, name = "Bitcoin", iName = "BTC", currency = 19131.7, changes = 1.9434},
            new Crypto{Id = 3, name = "Ripple", iName = "XRP", currency = 0.4835, changes = 2.3714},
            new Crypto{Id = 4, name = "Tether", iName = "USDT", currency = 1, changes = 0},
            new Crypto{Id = 5, name = "Dogecoin", iName = "DOGE", currency = 0.06589, changes = 7.0512},
        };
        //Створенння методу, який повертає всі рядочки колекції
        [HttpGet]
        public IHttpActionResult GetAllCryptos()
        {
            if (_cryptoList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_cryptoList);
        }
        //Створенння методу, який повертає один рядочок колекції
        [HttpGet]
        public IHttpActionResult GetCrypto(int Id)
        {
            var crypto = _cryptoList.SingleOrDefault((p) => p.Id == Id);
            if (crypto == null)
            {
                return NotFound();
            }
            return Ok(crypto);
        }
        //Добавлення до колекції нового рядка
        [HttpPost]
        public IHttpActionResult AddCrypto(Crypto crypto)
        {
            _cryptoList.Add(crypto);
            if (_cryptoList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_cryptoList);
        }
        //Функція для видалення рядка
        [HttpDelete]
        public IHttpActionResult DeleteCrypto(int Id)
        {
            var crypto = _cryptoList.FirstOrDefault((p) => p.Id == Id);
            if (crypto == null)
            {
                return NotFound();
            }
            _cryptoList.Remove(crypto);

            if (_cryptoList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_cryptoList);
        }
        //Добавлення нового рядка
        [HttpPut]
        public IHttpActionResult UpdateCrypto(Crypto crypto)
        {
            if(crypto == null)
            {
                return NotFound();
            }
            int index = _cryptoList.FindIndex((p) => p.Id == crypto.Id);

            if (index == -1)
            {
                return NotFound();
            }
            _cryptoList.RemoveAt(index);
            _cryptoList.Add(crypto);

            if (_cryptoList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_cryptoList);
        }
    }
}
