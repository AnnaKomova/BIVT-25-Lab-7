using System.Runtime;

namespace Lab7.Blue
{
    public class Task5
    {
        public struct Sportsmen
        {
            private string _name;
            private string _surname;
            private int _place;
            private bool _setPlace = false;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsmen(string name, string surname)
            {
                if (name != null)
                    _name = name;
                else
                    _name = "";
                if (surname != null)
                    _surname = surname;
                else
                    _surname = "";
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (place < 0) return;
                if (_setPlace)      // если место уже установили вернуть без изменений
                {
                    return;
                }
                _place = place;
                _setPlace = true;
            }

            public void Print()
            {
                return;
            }
        }
        public struct Team
        {
            private string _name;
            private Sportsmen[] _sportsmen;
            private int _count;

            public string Name => _name;
            public Sportsmen[] Sportsmen
            {
                get
                {
                    Sportsmen[] copy = new Sportsmen[_sportsmen.Length];
                    for (int i = 0; i < copy.Length; i++)
                    {
                        copy[i] = _sportsmen[i];
                    }
                    return copy;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_sportsmen.Length == 0) return 0;
                    int sum = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        switch (_sportsmen[i].Place)
                        {
                            case 1:
                                sum += 5;
                                break;
                            case 2:
                                sum += 4;
                                break;
                            case 3:
                                sum += 3;
                                break;
                            case 4:
                                sum += 2;
                                break;
                            case 5:
                                sum += 1;
                                break;
                        }
                    }
                    return sum;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0)
                        return 0;
                    int top = _sportsmen[0].Place;
                    for (int i = 1; i < _sportsmen.Length; i++)
                    {
                        if (top > _sportsmen[i].Place)
                        {
                            top = _sportsmen[i].Place;
                        }
                    }
                    return top;
                }
            }
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsmen[6];
                _count = 0;
            }

            public void Add(Sportsmen name)
            {
                if (_name == null)
                    return;
                if (_count >= 6)
                {
                    return;
                }
                _sportsmen[_count] = name;
                _count++;
            }
            public void Add(Sportsmen[] names)
            {
                if (_count >= 6)
                {
                    return;
                }
                for (int i = 0; i < names.Length; i++)
                {
                    Add(names[i]);
                }
            }
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length <= 1)
                    return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                        }
                        else if (teams[j].TotalScore == teams[j + 1].TotalScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                return;
            }
        }
    }
}
