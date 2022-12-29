using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duffnization.Domain
{
    public class Playlist
    {
        public string Name { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();
    }
}
