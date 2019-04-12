using SongRedirector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{

    public enum VoteType
    {
        Upvote = 1,
        Downvote = 2
    }

    public class VoteModel
    {
        public VoteType VoteType { get; set; }

        public string ConfigName { get; set; }

        public Link Link { get; set; }
    }
}
