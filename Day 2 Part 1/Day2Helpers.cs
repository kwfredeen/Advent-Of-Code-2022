using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2_Part_1
{
    public class Day2Helpers
    {
        //opponent's plays
        public const string opponentRock = "A";
        public const string opponentPaper = "B";
        public const string opponentScissors = "C";

        //your plays
        public const string youRock = "X";
        public const string youPaper = "Y";
        public const string youScissors = "Z";

        //win draw or lose round
        public const string win = "Z";
        public const string draw = "Y";
        public const string lose = "X";

        /// <summary>
        /// Calculates a score for one round of elvish Rock Paper Scissors based pn rules outlined at https://adventofcode.com/2022/day/2
        /// </summary>
        /// <param name="opponentPlay">Shape your opponent plays. must be A, B, or C for Rock, Paper, and Scissors respectively</param>
        /// <param name="yourPlay">Shape you play. must be X, Y, or Z for Rock, Paper, and Scissors respectively</param>
        /// <returns>score of the round</returns>
        /// <exception cref="ArgumentException"> if either player's plays are not A,B,C or X,Y,Z</exception>
        public static int RoundScore(string opponentPlay, string yourPlay)
        {
            int score = 0;

            //add the score for the shape you played
            score += yourPlay switch
            {
                youRock => 1,
                youPaper => 2,
                youScissors => 3,
                _ => throw new ArgumentException("your play must be X, Y, or Z"),
            };

            //add score from match result
            if (yourPlay == youRock)
            {
                score += opponentPlay switch
                {
                    opponentRock => 3, //draw
                    opponentScissors => 6, //win
                    opponentPaper => 0, //loss
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            }
            else if (yourPlay == youPaper)
            {
                score += opponentPlay switch
                {
                    opponentPaper => 3, //draw
                    opponentRock => 6, //win
                    opponentScissors => 0, //loss
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            } else if (yourPlay == youScissors)
            {
                score += opponentPlay switch
                {
                    opponentScissors => 3, //draw
                    opponentPaper => 6, //win
                    opponentRock => 0, //loss
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            }

            return score;
        }

        /// <summary>
        /// Gets the shape you need to play to get the desired round outcome, given the shape the opponent should play
        /// </summary>
        /// <param name="opponentPlay">shape opponent will play according to the strategy guide</param>
        /// <param name="desiredOutcome">whether you should win, lose, or draw the round, according to th strategy guide</param>
        /// <returns>shape you should play to get the desired outcome</returns>
        /// <exception cref="ArgumentException"> if opponent's play is not A,B,C or desired outcome is not X,Y, or Z</exception>
        public static string outcomeToPlay(string opponentPlay, string desiredOutcome)
        {
            if (desiredOutcome == win)
            {
                return opponentPlay switch
                {
                    opponentRock => youPaper,
                    opponentPaper => youScissors,
                    opponentScissors => youRock,
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            }
            else if (desiredOutcome == draw)
            {
                return opponentPlay switch
                {
                    opponentRock => youRock,
                    opponentPaper => youPaper,
                    opponentScissors => youScissors,
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            }
            else if (desiredOutcome == lose)
            {
                return opponentPlay switch
                {
                    opponentRock => youScissors,
                    opponentPaper => youRock,
                    opponentScissors => youPaper,
                    _ => throw new ArgumentException("opponent play must be A, B, or C")
                };
            }
            else throw new ArgumentException("desired outcome must be X, Y, or Z");
        }
    }
}

/* Improvements:
 *  - using strings as function inputs isn't great. I've almost made a few mistakes passing in the wrong strings 
 */
