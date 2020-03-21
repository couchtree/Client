using System.CodeDom;
using Boo.Lang;
using Models;

namespace Interfaces
{
    public interface PlayerInterface
    {
        string Name { get; set; }
        long lat { get; set; }
        long lon { get; set; }
    }
}