using System;

namespace AspNetCoreRazor.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ObjetoEscuelaBase()
        {
            
        }

        public override string ToString()
        {
            return $"{Name},{Id}";
        }
    }
}