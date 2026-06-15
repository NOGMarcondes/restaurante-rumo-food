using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string name { get; set; }

        public string email { get; set; }
        
        public string senha { get; set; }

        public string perfil { get; set; }


    }
}
