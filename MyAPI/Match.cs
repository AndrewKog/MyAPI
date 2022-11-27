using System;
using System.Collections.Generic;

namespace MyAPI
{
    public enum Sports
    {
        Football,
        Basketball 
    }
    public class Match
    {
        private int id;
        private string description = string.Empty;
        private DateTime matchDate;
        private DateTime matchTime;
        private string teamA = string.Empty;
        private string teamB = string.Empty;
        private Sports sport;
        private List<MatchOdd> matchOdds;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime MatchDate
        {
            get { return matchDate; }
            set { matchDate = value; }
        }

        public DateTime MatchTime
        {
            get { return matchTime; }
            set { matchTime = value; }
        }

        public string TeamA
        {
            get { return teamA; }
            set { teamA = value; }
        }

        public string TeamB
        {
            get { return teamB; }
            set { teamB = value; }
        }

        public Sports Sport   
        {
            get { return sport; }
            set { sport = value; }   
        }

        public List<MatchOdd> MatchOdds
        {
            get { return matchOdds; }
            set { matchOdds = value; }
        }


    }
}
