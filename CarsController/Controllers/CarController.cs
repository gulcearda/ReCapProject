using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        //Loose coupled
        //gevşek bağlılık bir bağlılık var ama soyuta, manager değişse mesela problem olmaz.
        ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        //bunu yazmamıza rağmen gelmedi unable resolve dedi çünkü veriye constructerdan erişilmez.
        //yukarı da somut referans yok bu nedenle bunu çözmek için IoC container kullanılır.



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger bize dokümantasyon verilir bu apilerin nasıl ne amaçla kullanıldığına dair
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

            //Dependency chain --
            //ICarService carService = new CarManager(new EfCarDal());
            //var result = carService.GetAll();
            //return result.Data;

            //hoca bunu yazdı ve bende çizdi ama hocada çizmedi. Burada tablolar gelecek.
            //gelmediğinde hoca icarservise breakpoint koydu.ama bunu da bozdu.
            //çünkü sistemde bir bakım koymuştu hoca bu engelliyordu.
            //hoca buna komment koyup kaldırdı.


            //[HttpGet]
            //public string Get()
            //{
            //    return "Merhaba";
            //};

            //Hocanın diğer yazıkları; bende çalışmıyor
            //return new List<Car>
            //{
            //  new Car{CarId=1, CarName="Hyundai"},
            //}
            //bunların hepsi httpgetin içinde
        }


        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

            //karşı taraftan veri alırız ve sisteme ekleriz.
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

            //ife breakpoint koyuyoruz.
            //hata alırız. Çünkü id istediğimiz için bunu anlamıyor
            //id istemeliyiz en güzeli isimlendirmedir.
            //isimleri değiştirdik ve şimdi çağırıyoruz. Postmanda sona isimlerini yazarız kodlamada 
        }

    }
}