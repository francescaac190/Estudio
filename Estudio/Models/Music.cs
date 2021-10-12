using System.ComponentModel.DataAnnotations;

namespace Estudio.Models
{ 
    public class Music
    {
        [Key]

        public int MusicId { get; set; }

        //holan
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(60, MinimumLength = 5,ErrorMessage = "El nombre debe que tener entre 5 a 60 caracteres")]
        [Display(Name ="Nombre de la cancion")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "El nombre del autor debe que tener entre 5 a 60 caracteres")]
        [Display(Name = "Nombre del autor")]
        public string Autor { get; set; }


        [Required(ErrorMessage = "Letra de la cancion")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Letra de la cancion")]
        [Display(Name = "Letra")]
        public string Letra { get; set; }

    }
}
