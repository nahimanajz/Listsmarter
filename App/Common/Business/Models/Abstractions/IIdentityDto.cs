using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.Models.Abstractions
{
    public interface IIdentityDto
    {
        public Guid Id { get; set; }
    }
}
