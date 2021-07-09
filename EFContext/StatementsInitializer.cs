using EFCourtStatements.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFCourtStatements.EFContext
{
    class StatementsInitializer : CreateDatabaseIfNotExists<StatementsContext>
    {
        protected override void Seed(StatementsContext context)
        {
            List<TypeST> OCTypeST = new List<TypeST>()
            {
                new TypeST
                {
                    TypeSTId = 1,
                    NameType = "1,15",
                    StatInfos = new List<StatInfo>()
                },
                new TypeST
                {
                    TypeSTId = 2,
                    NameType = "1,17",
                    StatInfos = new List<StatInfo>()
                },
                new TypeST
                {
                    TypeSTId = 3,
                    NameType = "другое",
                    StatInfos = new List<StatInfo>()
                }

            };
            List<Judge> OCJudge = new List<Judge>()
            {
                new Judge
                {
                    JudgeId = 1,
                    LastName = "Бричков",
                    FirstName = "В",
                    SName = "Б",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 2,
                    LastName = "Липневич",
                    FirstName = "Н",
                    SName = "Н",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 3,
                    LastName = "Осипенко",
                    FirstName = "Е",
                    SName = "М",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 4,
                    LastName = "Кузьмич",
                    FirstName = "А",
                    SName = "Н",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 5,
                    LastName = "Лешкевич",
                    FirstName = "М",
                    SName = "Н",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 6,
                    LastName = "Шумская",
                    FirstName = "Т",
                    SName = "Н",
                    StatInfos = new List<StatInfo>()
                },
                new Judge
                {
                    JudgeId = 7,
                    LastName = "Фомина",
                    FirstName = "Н",
                    SName = "С",
                    StatInfos = new List<StatInfo>()
                }
            };
            List<StatInfo> OCStatInf = new List<StatInfo>()
            {
                new StatInfo
                {
                    Number = 23569,
                    //TypeSTId = OCTypeST[0].TypeSTId, //1,
                    //JudgeId = OCJudge[0].JudgeId, //1,
                    PersName = "Василевская Ольга Геннадьевна",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 03, 01),
                    DataCorrect = new DateTime(2021, 03, 12)
                },
                new StatInfo
                {
                    Number = 23588,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[1].JudgeId,// 2,
                    PersName = "ОАО \"Белгазпромбанк\"",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 03, 03),
                    DataCorrect = new DateTime(2021, 03, 12)
                },
                new StatInfo
                {
                    Number = 25123,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[2].JudgeId,// 3,
                    PersName = "Головик Максим Геннадьевич",
                    Kategory = "иск о расторжении брака",
                    InDate = new DateTime(2021, 03, 03),
                    DataCorrect = new DateTime(2021, 03, 13)
                },
                new StatInfo
                {
                    Number = 25226,
                    //TypeSTId = OCTypeST[1].TypeSTId,// 2,
                    //JudgeId = OCJudge[3].JudgeId,// 4,
                    PersName = "Марьин Витольд Максимович",
                    Kategory = "жалоба",
                    InDate = new DateTime(2021, 03, 04)
                },
                new StatInfo
                {
                    Number = 26236,
                    //TypeSTId = OCTypeST[1].TypeSTId,// 2,
                    //JudgeId = OCJudge[4].JudgeId,// 5,
                    PersName = "Веревко Игорь Васильевич",
                    Kategory = "иск о разделе имущества",
                    InDate = new DateTime(2021, 04, 03)
                },
                new StatInfo
                {
                    Number = 26856,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[5].JudgeId,// 6,
                    PersName = "ОДО \"Промсвязь\"",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 04, 15),
                    DataCorrect = new DateTime(2021, 04, 29)
                },
                new StatInfo
                {
                    Number = 26857,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[6].JudgeId,// 7,
                    PersName = "ОДО \"Промсвязь\"",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 04, 15),
                    DataCorrect = new DateTime(2021, 05, 01)
                },
                new StatInfo
                {
                    Number = 27365,
                    //TypeSTId = OCTypeST[1].TypeSTId,// 2,
                    //JudgeId = OCJudge[0].JudgeId,// 1,
                    PersName = "Мартинович Григорий",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 04, 17)
                },
                new StatInfo
                {
                    Number = 27400,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[1].JudgeId,// 2,
                    PersName = "Красновская Ирина Станиславовна",
                    Kategory = "иск о расторжении брака",
                    InDate = new DateTime(2021, 04, 20),
                    DataCorrect = new DateTime(2021, 05, 01)
                },
                new StatInfo
                {
                    Number = 27698,
                    //TypeSTId = OCTypeST[2].TypeSTId,// 3,
                    //JudgeId = OCJudge[2].JudgeId,// 3,
                    PersName = "Волчек Инна Александровна",
                    Kategory = "о взыскании алиментов в приказном порядке",
                    InDate = new DateTime(2021, 05, 02)
                },
                new StatInfo
                {
                    Number = 28003,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[3].JudgeId,// 4,
                    PersName = "Григорчик Роман",
                    Kategory = "иск о взыскании денежных средств",
                    InDate = new DateTime(2021, 05, 17),
                    DataCorrect = new DateTime(2021, 06, 01)
                },
                new StatInfo
                {
                    Number = 28015,
                    //TypeSTId = OCTypeST[0].TypeSTId,// 1,
                    //JudgeId = OCJudge[4].JudgeId,// 5,
                    PersName = "Славнова Мария Олеговна",
                    Kategory = "иск о разделе имущества",
                    InDate = new DateTime(2021, 05, 18),
                    DataCorrect = new DateTime(2021, 06, 05)
                },
                new StatInfo
                {
                    Number = 28345,
                    //TypeSTId = OCTypeST[2].TypeSTId,// 3,
                    //JudgeId = OCJudge[5].JudgeId,// 6,
                    PersName = "Василевская Ольга Геннадьевна",
                    Kategory = "о взыскании алиментов в приказном порядке",
                    InDate = new DateTime(2021, 05, 21)
                },
                new StatInfo
                {
                    Number = 28346,
                    //TypeSTId = OCTypeST[1].TypeSTId,// 2,
                    //JudgeId = OCJudge[6].JudgeId,// 7,
                    PersName = "Василевская Ольга Геннадьевна",
                    Kategory = "иск о расторжении брака",
                    InDate = new DateTime(2021, 05, 29)
                }
            };

            //цикл, заполняющий коллекцию заявлений в типе
            for (int i = 0; i < OCTypeST.Count; i++)
            {
                for (int j = 0; j < OCStatInf.Count; j++)
                {
                    if (OCStatInf[j].TypeSTId == OCTypeST[i].TypeSTId)
                        OCTypeST[i].StatInfos.Add(OCStatInf[j]);
                }
            }
            //цикл, заполняющий коллекцию заявлений в судьях
            for (int i = 0; i < OCJudge.Count; i++)
            {
                for (int j = 0; j < OCStatInf.Count; j++)
                {
                    if (OCStatInf[j].JudgeId == OCJudge[i].JudgeId)
                        OCJudge[i].StatInfos.Add(OCStatInf[j]);
                }
            }

            context.StatementsInfo.AddRange(OCStatInf);
            context.TypesSt.AddRange(OCTypeST);
            context.Judges.AddRange(OCJudge);

            context.SaveChanges();

            context.StatementsInfo.Find(1).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(1).JudgeId = OCJudge[0].JudgeId;

            context.StatementsInfo.Find(2).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(2).JudgeId = OCJudge[1].JudgeId;

            context.StatementsInfo.Find(3).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(3).JudgeId = OCJudge[2].JudgeId;

            context.StatementsInfo.Find(4).TypeSTId = OCTypeST[1].TypeSTId;
            context.StatementsInfo.Find(4).JudgeId = OCJudge[3].JudgeId;

            context.StatementsInfo.Find(5).TypeSTId = OCTypeST[1].TypeSTId;
            context.StatementsInfo.Find(5).JudgeId = OCJudge[4].JudgeId;

            context.StatementsInfo.Find(6).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(6).JudgeId = OCJudge[5].JudgeId;

            context.StatementsInfo.Find(7).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(7).JudgeId = OCJudge[6].JudgeId;

            context.StatementsInfo.Find(8).TypeSTId = OCTypeST[1].TypeSTId;
            context.StatementsInfo.Find(8).JudgeId = OCJudge[0].JudgeId;

            context.StatementsInfo.Find(9).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(9).JudgeId = OCJudge[1].JudgeId;

            context.StatementsInfo.Find(10).TypeSTId = OCTypeST[2].TypeSTId;
            context.StatementsInfo.Find(10).JudgeId = OCJudge[2].JudgeId;

            context.StatementsInfo.Find(11).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(11).JudgeId = OCJudge[3].JudgeId;

            context.StatementsInfo.Find(12).TypeSTId = OCTypeST[0].TypeSTId;
            context.StatementsInfo.Find(12).JudgeId = OCJudge[4].JudgeId;

            context.StatementsInfo.Find(13).TypeSTId = OCTypeST[2].TypeSTId;
            context.StatementsInfo.Find(13).JudgeId = OCJudge[5].JudgeId;

            context.StatementsInfo.Find(14).TypeSTId = OCTypeST[1].TypeSTId;
            context.StatementsInfo.Find(14).JudgeId = OCJudge[6].JudgeId;

            context.SaveChanges();
        }
    }
}
