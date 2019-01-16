using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstASP.Models
{
    public class Users
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]  
        public string FIO { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]      
        public string login { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 15 символов")]
        public string password { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string email { get; set; }
        [HiddenInput(DisplayValue = false)]
        public bool admin { get; set; }
    }
}