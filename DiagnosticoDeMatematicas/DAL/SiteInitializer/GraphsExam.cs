namespace DiagnosticoDeMatematicas.DAL
{
    using Models;

    public partial class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        private void GraphsExams()
        {
            Exams.Add(new Exam
            {
                ID = ++ExamCounter,
                Name = "Gráficas",
                Description = "Este es un examen de gráficas que permite el desarrollo de habilidades basicas matematicas.",
                Active = true
            });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquella que pasa por el punto (0,%n)",
                OptionA = "&& Polynomial -5 5 -5 5 %n &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 %n 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "En x=0 se tiene y=0 y en x=n se tiene y=n.",
                OptionC = "&& VerticalLine -5 5 -5 5 %n &&",
                OptionCCorrect = false,
                OptionCFeedback = "Elige que pasa por (n,0) confundiendo 'x' e 'y'.",
                OptionD = "&& Polynomial -5 5 -5 5 -1 |2*%n| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Elige recta que pasa por (0,2n) y (n,n)."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -3, Maximum = -1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las sigueintes gráficas de rectas, elige la única que no pasa por el punto (%n,%n)",
                OptionA = "&& Polynomial -5 5 -5 5 -1 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 1 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Pasa por (0,0) y (n,n)",
                OptionC = "&& VerticalLine -5 5 -5 5 %n &&",
                OptionCCorrect = false,
                OptionCFeedback = "En x=n 'y' toma todos los valores, en particular y=n",
                OptionD = "&& Polynomial -5 5 -5 5 %n &&",
                OptionDCorrect = false,
                OptionDFeedback = "En todo 'x' se tiene y=n."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -3, Maximum = -1 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, escoge aquella cuya pendiente es mayor a %n.",
                OptionA = "&& Polynomial -8 8 -8 8 |6.0 / 5.0 * %n| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -8 8 -8 8 |5.0 / 6.0 * %n| 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Pendiente igual a (5/6)n que no es mayor a n.",
                OptionC = "&& Polynomial -8 8 -8 8 %n 0 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Pendiente igual a n, que no es mayor a n.",
                OptionD = "&& Polynomial -8 8 -8 8 |%n + 1.0 / 2.0| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Pendiente igual a cero."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "De las sigueintes gráficas de rectas, escoge aquella cuya pendiente es menor a %n.",
                OptionA = "&& Polynomial -8 8 -8 8 |%n * 3.0 / 4.0| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& VerticalLine -8 8 -8 8 |%n - 1.0 / 2.0| &&",
                OptionBCorrect = false,
                OptionBFeedback = "La pendiente está indefinida.",
                OptionC = "&& Polynomial -8 8 -8 8 %n 0 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Su pendiente es n.",
                OptionD = "&& Polynomial -8 8 -8 8 |%n * 4.0 / 3.0| 0 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Su pendiente es mayor que n."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Elige entre las siguietnes gráficas aquélla que tiene una pendiente negativa.",
                OptionA = "&& Polynomial -5 5 -5 5 -|%n / %m| -1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 -|%n / %m| &&",
                OptionBCorrect = false,
                OptionBFeedback = "Su pendiente es cero.",
                OptionC = "&& Polynomial -5 5 -5 5 |%n / %m| -1 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Su pendiente es positiva.",
                OptionD = "&& VerticalLine -5 5 -5 5 -|%n / %m| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Su pendiente está indefinida."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, escoge la que es decreciente.",
                OptionA = "&& Polynomial -5 5 -5 5 -|%n / %m| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%n / %m| 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Ésta es creciente.",
                OptionC = "&& Polynomial -5 5 -5 5 -|%n / %m| &&",
                OptionCCorrect = false,
                OptionCFeedback = "No cambian los valores",
                OptionD = "&& Polynomial -5 5 -5 5 |%n / %m| -2 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Ésta es creciente."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las sigueintes rectas elige la que manifiesta que cuando 'x' crece entonces 'y' decrece.",
                OptionA = "&& Polynomial -5 5 -5 5 -|%n / %m| 3 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%n / %m| 3 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Aquí 'y' crece cuando 'x' crece.",
                OptionC = "&& Polynomial -5 5 -5 5 3 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Aquí 'y' se mantiene igual.",
                OptionD = "&& Polynomial -5 5 -5 5 -|%n / %m| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Aquí 'y' se mantiene igual, aunque negativa."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
        }
    }
}


/*
            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas debes elegir aquella que satisface la siguiente: con cada cambio en 'x' de una unidad, se tiene un cambio en 'y' de \\(\\dfrac{1}{%n}\\) unidades.",
                OptionA = "&& Polynomial -5 5 -5 5 |1/%n| 1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 %n 1 &&",
                OptionBCorrect = false,
                OptionBFeedback = "}Intercambio de roles de 'x' e 'y'.",
                OptionC = "&& Polynomial -5 5 -5 5 -|1/%n| 1  &&",
                OptionCCorrect = false,
                OptionCFeedback = "Signo que afecta el comportamiento creciente/decreciente.",
                OptionD = "&& Polynomial -5 5 -5 5 -%n 1 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Intercambio de roles de 'x' e 'y' y además de signo que afecta el comportamiento creciente/decreciente."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -5, Maximum = -2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas escoge la que cumple que cuando x=0, se tiene y=%m y cuando y=0, se tiene que x=%n",
                OptionA = "&& Polynomial -5 5 -5 5 -|%m/%n| %m &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%m/%n| %m &&",
                OptionBCorrect = false,
                OptionBFeedback = "Error en signo en corte del eje 'x'",
                OptionC = "&& Polynomial -5 5 -5 5 -|%m/%n| -%m &&",
                OptionCCorrect = false,
                OptionCFeedback = "Error en signo de corte del eje 'y'.",
                OptionD = "&& Polynomial -5 5 -5 5 |%m/%n| -%m &&",
                OptionDCorrect = false,
                OptionDFeedback = "Error en signo en corte con ejes 'x' e 'y'."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -2, Maximum = -2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -4, Maximum = -4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -6, Maximum = -6 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -1, Maximum = -1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -3, Maximum = -3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -5, Maximum = -5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las sigueintes gráficas, escoge aquélla que cumple que con cada cambio en 'x' de una unidad, se tiene un cambio en 'y' de \\(\\dfrac{%n}{%m}\\) unidades.",
                OptionA = "&& Polynomial -5 5 -5 5 |%n/%m| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%m/%n| 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Intercambio de roles de 'x' e 'y'.",
                OptionC = "&& Polynomial -5 5 -5 5 -|%n/%m| 0 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Signo del cambio de 'y' no considerado.",
                OptionD = "&& Polynomial -5 5 -5 5 -|%m/%n| 0 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Intercambio de roles de 'x' e 'y' y falta considerar el signo del cambio de 'y'."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -2, Maximum = -2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -4, Maximum = -4 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });


        OCHO OCHO

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquélla que pasa por el punto (-|%n+1|, n).",
                OptionA = "&& Polynomial -10 10 -10 10 |%n/(%n+1)| |2*%n| &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -10 10 -10 10 |%n/(%n+1)| %n &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión de punto con sus coordenadas por separado en los ejes.",
                OptionC = "&& Polynomial -10 10 -10 10 |(%n+1)/%n| -|%n+1| &&",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión de punto con sus coordenadas por separado y cambio de 'x' por 'y' y viceversa.",
                OptionD = "&& Polynomial -10 10 -10 10 |(%n+1)/%n| -|2*(%n+1)| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Confusción de 'x' por 'y' y 'y' por 'x' en las coordenadas del punto."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 5 });

    */
