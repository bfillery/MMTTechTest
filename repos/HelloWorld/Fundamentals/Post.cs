using System;
using System.Collections.Generic;

namespace HelloWorld.Fundamentals
{
    public class Post
    {
        public enum VoteDirection
        {
            Up = 1,
            Down = -1
        }

        private Dictionary<DateTime,VoteDirection> Votes;

        public string Title { get; set; }

        public string Description { get; set; }



        public Post()
        {
            Votes = new Dictionary<DateTime, VoteDirection>();
        }

        public Post(string title)
            :this()
        {
            Title = title;
        }

        public Post(string title, string description)
            :this(title)
        {
            Description = description;
        }



        public int GetVoteTally()
        {
            int VoteTally = 0;

            foreach (var vote in Votes)
                {
                VoteTally += (int)vote.Value;
            }
            return VoteTally;
        }

        public Dictionary<DateTime,VoteDirection> GetVotes()
        {
            return Votes;
        }

        public void AddVote(VoteDirection theVote, DateTime DateCreated)
        {
            //can't go below 0
            if(theVote == VoteDirection.Up || GetVoteTally() > 0)
                Votes.Add(DateCreated, theVote);
        }


        //INDEXER
        public VoteDirection this[DateTime key]
        {
            get { return Votes[key]; }
            set { Votes[key] = value; }
        }
    }
}
