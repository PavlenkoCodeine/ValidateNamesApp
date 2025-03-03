using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidateNames_API.Models;

namespace ValidateNames_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>()
        {
            new User() { Fullname = "Смир@нова Анна Витальев!на"},
            new User() { Fullname= "Орлов Игорь Александрович"},
            new User() { Fullname= "Кузнецова Марина Геннадиевна"},
            new User() { Fullname= "Василь*ев Юрий Петрович"},
            new User() { Fullname= "Ива3нова Ели1завета Констант!иновна"},
            new User() { Fullname= "Федоров Михаил Борисович"},
            new User() { Fullname= "Сидорова Виктория Вячеславовна"},
            new User() { Fullname= "По!пов Ар#тем Евгеньевич"},
            new User() { Fullname= "Морозова Дарья Владимировна"},
            new User() { Fullname= "Соколов Роман Лео$нидович"},
            new User() { Fullname= "Волк%ова Анастасия Максимовна"},
            new User() { Fullname= "Николаев Ден#ис Иль!ич"},
            new User() { Fullname= "Романова Ксения Эдуардовна"},
            new User() { Fullname= "Козлова Полина Валерьевна"},
            new User() { Fullname= "Лебедев Антон Николаевич"},
            new User() { Fullname= "Зайц&ева Вера Дмитри^евна"},
            new User() { Fullname= "Сергеева Ири&на Станиславовна"},
            new User() { Fullname= "Пономарев Глеб Сергеевич"},
            new User() { Fullname= "Дмитриева Кристина Алексеевна"},
            new User() { Fullname= "Тимофеев Ни%кита Владиславович"},
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_users);
        }
    }
}
