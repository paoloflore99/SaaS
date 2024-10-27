using System.ComponentModel.DataAnnotations;

namespace SaaS.Models
{
    public class Prova
    {
        [Key]
        public int Id { get; set; }
        public string? prova { get; set; }

        public Prova() { }
        public Prova(string? prova)
        {
            this.prova = prova;
        }
    }
}
