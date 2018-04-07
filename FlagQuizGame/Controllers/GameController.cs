using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlagQuizGame.Models;

namespace FlagQuizGame.Controllers
{
    public class GameController : Controller
    {

        // GET: Game
        public ActionResult Flags(int id)
        {
            Game currentGame;

            if(id == 1)
            {
                currentGame = InitializeGame();
            }
            else
            {
                currentGame = TempData["game"] as Game;
            }

            SaveGameState(currentGame);

            return View("Index", currentGame.Answers.FirstOrDefault(x => x.Id == id));
        }

        private Game InitializeGame()
        {
            var answers = InitializeAnswers();

            var game = new Game
            {
                Answers = answers
            };

            return game;
        }

        private List<Answer> InitializeAnswers()
        {
            var answers = new List<Answer>();

            for (var i = 1; i <= 10; i++)
            {
                answers.Add(GetAnswer(i));
            }

            return answers;
        }

        private Answer GetAnswer(int answerId)
        {
            switch (answerId)
            {
                case 1:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 1,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 1, Country = "Brazil"},
                            new Flag{Id = 2, Country = "Argentina"},
                            new Flag{Id = 3, Country = "Uruguay"},
                            new Flag{Id = 4, Country = "Paraguay"},
                        },
                        Value = 10
                    };
                case 2:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 2,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 6, Country = "United States"},
                            new Flag{Id = 2, Country = "Argentina"},
                            new Flag{Id = 3, Country = "Uruguay"},
                            new Flag{Id = 5, Country = "Canada"},
                        },
                        Value = 20

                    }; 
                case 3:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 3,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 6, Country = "Canada"},
                            new Flag{Id = 2, Country = "Argentina"},
                            new Flag{Id = 1, Country = "Brazil"},
                            new Flag{Id = 3, Country = "Uruguay"},
                        },
                        Value = 30

                    }; 
                case 4:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 4,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 9, Country = "Spain"},
                            new Flag{Id = 4, Country = "Paraguay"},
                            new Flag{Id = 10, Country = "Germany"},
                            new Flag{Id = 7, Country = "Mexico"},
                        },
                        Value = 40

                    }; 
                case 5:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 5,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 5, Country = "Canada"},
                            new Flag{Id = 2, Country = "Argentina"},
                            new Flag{Id = 8, Country = "Portugal"},
                            new Flag{Id = 3, Country = "Uruguay"},
                        },
                        Value = 50

                    };
                case 6:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 6,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 7, Country = "Mexico"},
                            new Flag{Id = 6, Country = "United States"},
                            new Flag{Id = 1, Country = "Brazil"},
                            new Flag{Id = 10, Country = "Germany"},
                        },
                        Value = 60

                    };
                case 7:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 7,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 5, Country = "Canada"},
                            new Flag{Id = 9, Country = "Spain"},
                            new Flag{Id = 4, Country = "Paraguay"},
                            new Flag{Id = 7, Country = "Mexico"},
                        },
                        Value = 70

                    };
                case 8:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 8,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 8, Country = "Portugal"},
                            new Flag{Id = 1, Country = "Brazil"},
                            new Flag{Id = 7, Country = "Mexico"},
                            new Flag{Id = 6, Country = "United States"},
                        },
                        Value = 80

                    };
                case 9:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 9,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 10, Country = "Germany"},
                            new Flag{Id = 2, Country = "Argentina"},
                            new Flag{Id = 9, Country = "Spain"},
                            new Flag{Id = 1, Country = "Brazil"},
                        },
                        Value = 90

                    };
                case 10:
                    return new Answer
                    {
                        Id = answerId,
                        CorrectAnswerId = 10,
                        Options = new List<Flag>()
                        {
                            new Flag{Id = 3, Country = "Uruguay"},
                            new Flag{Id = 5, Country = "Canada"},
                            new Flag{Id = 7, Country = "Mexico"},
                            new Flag{Id = 10, Country = "Germany"},
                        },
                        Value = 10

                    };
            }

            return null;
        }

        [HttpPost]
        public ActionResult ValidateAnswer(int answerId, int optionId)
        {
            var game = TempData["game"] as Game;
 
            var answer = game.Answers.FirstOrDefault(x => x.Id == answerId);

            if (answer.CorrectAnswerId == optionId)
            {
                game.CorrectAnswers++;
                game.Points += answer.Value;
                SaveGameState(game);
                return Json(new {correct = true});
            }

            SaveGameState(game);
            return Json(new {correct = false});

        }

        private void SaveGameState(Game game)
        {
            TempData["game"] = game;
        }

        public ActionResult Result()
        {
            var currentGame = TempData["game"] as Game;
            SaveGameState(currentGame);
            return View("Result", currentGame);
        }
    }
}
