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

            // 8 CORREGIR
            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquella que pasa por el punto (-|%n+1|, %n)",
                OptionA = "&& Polynomial -5 5 -5 5 %n 1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |1.0/%n| 1 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión en el rol de x e y. Intercambiado.",
                OptionC = "&& Polynomial -5 5 -5 5 -%n 1 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretación de aumento en 'y' incorrecto.",
                OptionD = "&& Polynomial -5 5 -5 5 -|1.0/%n| 1 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión del rol de 'x' e 'y' y de interpretación del aumento en 'y'."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes rectas, elige la que cumple lo siguiente: cada vez que 'x' aumenta una unidad, 'y' aumenta %n unidades.",
                OptionA = "&& Polynomial -5 5 -5 5 %n 1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |1.0/%n| 1 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión en el rol de x e y. Intercambiado.",
                OptionC = "&& Polynomial -5 5 -5 5 -%n 1 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretación de aumento en 'y' incorrecto.",
                OptionD = "&& Polynomial -5 5 -5 5 -|1.0/%n| 1 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión del rol de 'x' e 'y' y de interpretación del aumento en 'y'."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas escoge aquella que cumple que cada vez que 'y' aumenta una unidad, se tiene que 'x' aumenta %n unidades.",
                OptionA = "&& Polynomial -5 5 -5 5 |1.0/%n| 1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 %n 1 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusción en rol de 'x' e 'y' intercambiado.",
                OptionC = "&& Polynomial -5 5 -5 5 |1.0/(%n-1)| 1 &&",
                OptionCCorrect = false,
                OptionCFeedback = "En el momento de interpretar aumento de 'x' considera n-1 y no n.",
                OptionD = "&& Polynomial -5 5 -5 5 |%n-1| 1 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión en el rol de 'x' e 'y' además de considerar el aumento de n-1 y no n."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Escoge la recta cuya pendiente es \\(\\dfrac{%m}{%n}\\)",
                OptionA = "&& Polynomial -5 5 -5 5 |%m/%n| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%n/%m| 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión del rol de x e y intercambiado.",
                OptionC = "&& Polynomial -5 5 -5 5 -|%n/%m| %n &&",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión de números en la pendiente con intersecciones en los ejes cartesianos.",
                OptionD = "&& Polynomial -5 5 -5 5 -|%m/%n| %m &&",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión de números en la pendiente con intersecciones con ejes además de intercambio de roles de x e y."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquella cuya pendiente es \\(\\dfrac{1}{%n}\\) y pasa por el punto (0,%n)",
                OptionA = "&& Polynomial -5 5 -5 5 |1/%n| %n &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 %n |1/%n| &&",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión de pendiente con corte en eje y y viceersa.",
                OptionC = "&& Polynomial -5 5 -5 5 %n %n &&",
                OptionCCorrect = false,
                OptionCFeedback = "Elección considerante solamente el corte con el eje y.",
                OptionD = "&& Polynomial -5 5 -5 5 |1/%n| |1/%n| &&",
                OptionDCorrect = false,
                OptionDFeedback = "Elección considerando sólamente la pendiente."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 6 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguietnes gráficas de rectas, escoge la que tiene una pendiente igual a \\(\\dfrac{-1}{%n}\\) y que pasa por el punto (%n,0).",
                OptionA = "&& Polynomial -5 5 -5 5 -|1/%n| 1 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 -|1/%n| %n &&",
                OptionBCorrect = false,
                OptionBFeedback = "Intercambio de rol de x e y en coordenadas del punto (n,0)",
                OptionC = "&& Polynomial -5 5 -5 5 -%n |%n*%n| &&",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretación de la pendiente intercambiando el rol de x con y.",
                OptionD = "&& Polynomial -5 5 -5 5 -%n %n &&",
                OptionDCorrect = false,
                OptionDFeedback = "Intercambio de la x e y en punto y en la interpretación de la pendiente."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 6 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes gráficas de rectas, elige la que muesta que cada vez que 'x' aumenta %m unidades, la 'y' aumenta %n unidades.",
                OptionA = "&& Polynomial -5 5 -5 5 |%n/%m| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 |%m/%n| 0 &&",
                OptionBCorrect = false,
                OptionBFeedback = "Intercambio de rol en 'x' e 'y'",
                OptionC = "&& Polynomial -5 5 -5 5 -|%m/%n| %m &&",
                OptionCCorrect = false,
                OptionCFeedback = "Asocia la pendiente con las intersecciones e intercambia el rol de 'x' e 'y'.",
                OptionD = "&& Polynomial -5 5 -5 5 -|%n/%m| %n &&",
                OptionDCorrect = false,
                OptionDFeedback = "Asocia la pendiente con las interseccion con los ejes."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });

            // FALTA 15

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las sigueintes gr[aficas de rectas, escoge aqu[ella que comple que su coordenada 'x' siempre vale lo mismo.",
                OptionA = "&& VerticalLine -5 5 -5 5 %n &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& Polynomial -5 5 -5 5 %n &&",
                OptionBCorrect = false,
                OptionBFeedback = "Intercambio de roles en 'x' e 'y'",
                OptionC = "&& Polynomial -5 5 -5 5 1 0 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretar que 'x' siempre valga lo mismo que 'y'.",
                OptionD = "&& Polynomial -5 5 -5 5 |%n| 0 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Interpretar que en la recta hay algo constante, su inclinación."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -3, Maximum = -1 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Escoge entre las siguientes gráficas de rectas aquella que representa que el valor de 'y' no cambia a pesar de que el de 'x' cambia.",
                OptionA = "&& Polynomial -5 5 -5 5 %n| 0 &&",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "&& VerticalLine -5 5 -5 5 %n &&",
                OptionBCorrect = false,
                OptionBFeedback = "Intercambio del rol de 'x' e 'y'.",
                OptionC = "&& Polynomial -5 5 -5 5 1 0 &&",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretar que el valor de 'y' se mantiene igual al de 'x'.",
                OptionD = "&& Polynomial -5 5 -5 5 %n 0 &&",
                OptionDCorrect = false,
                OptionDFeedback = "Interpretar que lo que no cambia es el valor de la pendiente."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -3, Maximum = -1 });

        }
    }
}
