using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Models
{
    public class PersonModel
    {
        public PersonModel(string name)
        {
            Name = name;
        }

        public Guid Id { get; init; }
        public string Name { get; set; }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void SetInactive()
        {
            Name = $"{Name} - desativado";
        }
    }
}



// get: retorna o valor da propriedade.
// set: atribui um valor à propriedade; dentro do set a palavra-chave value representa o valor atribuído.