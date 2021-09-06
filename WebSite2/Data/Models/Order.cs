using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite2.Data.Models
{
    public class Order
    {
        //Для установки отдельных свойств добавляем аттрибуты
        //Чтобы данное поле не показывалось на странице - BindNever
        //[BindNever]
        public int OrderId { get; set; }
     
        [Display(Name = "Имя")]                                  //Display - для задания имени свойства которое будет отображаться на странице                                                
        [StringLength(10)]                                       //StringLength - длина поля name не должна преваышать 10 символов
        [Required(ErrorMessage = "Недопустимая длина имени!!")]  //[Required(ErrorMessage="")] - вывод сообщения об тшибке
        public string name { get; set; }


        [Display(Name = "Фамилия")]
        [StringLength(12)]
        [Required(ErrorMessage = "Недопустимая длина фамилии")]
        public string surname { get; set; }


        [Display(Name = "Адрес")]
        [DataType(DataType.MultilineText)]                      //[DataType(DataType.MultilineText)]  - задает тип данных в конкретном поле
        [StringLength(20)]
        [Required(ErrorMessage = "Адрес слишком короткий")]
        public string adress { get; set; }

        [Display(Name = "Номер Телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage ="Слишком короткий номер")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage ="Слишком короткий адрес почтового ящика")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]                             //Для скрытия поля не только в окне но и в исходном коде страницы в браузере
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
