using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Word_of_ModJirawut.Models
{
    public class Project
    {
        [Key]
<<<<<<< HEAD
        

        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณาป้อนรหัสโปรเจ็กต์ด้วย")]
        [DisplayName("รหัสโปรเจ็กต์")]
        public int IdProduct { get; set; }

=======
        public int Id { get; set; }
>>>>>>> c533b1ce84d15fd0f29edef58a8be2228b33f338
        [Required(ErrorMessage = "กรุณาป้อนชื่อรายการด้วย")]
        [DisplayName("ชื่อรายการ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "กรุณาป้อนราคาต่อหน่วยด้วย")]
        [DisplayName("ราคาต่อหน่วย")]
        public float PriceUnit { get; set; }
        [Required(ErrorMessage = "กรุณาป้อนจำนวนด้วย")]
        [DisplayName("จำนวน")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "กรุณาป้อนราคารวมด้วย")]
        [DisplayName("ราคา")]
        public double Price { get; set; }
        [Required(ErrorMessage = "กรุณาป้อนหมายเหตุด้วย")]
        [DisplayName("หมายเหตุ")]
        public string Note { get; set; }
<<<<<<< HEAD


       
=======
>>>>>>> c533b1ce84d15fd0f29edef58a8be2228b33f338
    }
}
