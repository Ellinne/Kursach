//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GallerySite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Клиент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клиент()
        {
            this.Договор_на_продажу = new HashSet<Договор_на_продажу>();
            this.Договор_с_автором = new HashSet<Договор_с_автором>();
        }
    
        public int Код_клиента { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите фамилию.")]
        [StringLength(20, ErrorMessage = "Фамилия не может быть длиннее 20 символов.")]
        public string Фамилия { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите имя.")]
        [StringLength(15, ErrorMessage = "Имя не может быть длиннее 15 символов.")]
        public string Имя { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите отчество.")]
        [StringLength(15, ErrorMessage = "Отчество не может быть длиннее 15 символов.")]
        public string Отчество { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, обозначьте статус.")]
        [StringLength(15, ErrorMessage = "Статус не может быть длиннее 15 символов.")]
        public string Статус { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите номер телефона.")]
        [StringLength(10, ErrorMessage = "Номер телефона не может быть длиннее 10 символов.")]
        public string Телефон { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите серию паспорта.")]
        [StringLength(4, ErrorMessage = "Серия паспорта не может быть длиннее 4 символов.")]
        public string Серия_паспорта { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите номер паспорта.")]
        [StringLength(6, ErrorMessage = "Номер паспорта не может быть длиннее 6 символов.")]
        public string Номер_паспорта { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Договор_на_продажу> Договор_на_продажу { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Договор_с_автором> Договор_с_автором { get; set; }
    }
}
