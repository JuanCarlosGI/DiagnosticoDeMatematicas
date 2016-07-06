namespace DiagnosticoDeMatematicas.DAL
{
    using Models;

    public partial class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        private void FormulasExam()
        {
            Exams.Add(new Exam
            {
                ID = ++ExamCounter,
                Name = "Fórmulas",
                Description = "Este es un examen de fórmulas que permite el desarrollo de habilidades basicas matematicas.",
                Active = true
            });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las opciones dadas abajo, elige la que es equivalente a la siguiente: \\[" +
                "\\left ( x^{2} + |%n*%n| \\right )^{-2}" + "\\]",
                OptionA = "\\(\\dfrac{1}{\\left ( x^{2} + |%n*%n|\\right )^{2}}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{x^{4} + |%n*%n|^{2}}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Realiza suma de los cuadrados de cada término",
                OptionC = "\\(-\\left ( x^{2} + |%n*%n|\\right )^{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretación incorrecta de signo negativo en exponente.",
                OptionD = "\\(x^{-4} + |%n*%n|^{-2}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Distribuye el exponente en cada término."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguiente opciones elige la que es equivalente a la expresión algebraica. \\[" +
                "\\sqrt{x^{2} + |%n*%n|}" + "\\]",
                OptionA = "\\(\\left (x^{2} + |%n*%n|\\right )^{1/2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\sqrt{\\left (x+%n\\right )\\left (x-%n\\right )}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Aplica producto notable de diferencia de cuadrados en una suma de cuadrados",
                OptionC = "\\(x+%n\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Distribuye el radical en cada término y cancela el cuadrado con el radical.",
                OptionD = "\\(\\sqrt{\\left (x+%n\\right )^{2}}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Producto notable de binomio al cuadrado confundido con suma de cuadrados de cada término."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Simplifica la expresión dada en seguida y selecciona la opción que le corresponde \\[" +
                "\\left (\\dfrac{%nab^{|%n+1|}}{b^{%n}}\\right )^{-1}" + "\\]",
                OptionA = "\\(\\dfrac{1}{%nab}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(-%nab\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Exponente negativo confundido con cambio de signo.",
                OptionC = "\\(\\dfrac{%nab}{1}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No opera el exponente negativo.",
                OptionD = "\\(\\dfrac{%n}{ab}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera el exponente negativo sólo a las letras y no a los números."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Simplifica la expresión con radicales dada enseguida y elcoge la opción que la muestra. \\[" +
                "\\sqrt{x^{|2*%n|}y^{|19-2*%n|}}" + "\\]",
                OptionA = "\\(x^{%n}y^{|9-%n|}\\sqrt{y}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(x^{|2*%n|}y^{|18-2*%n|}\\sqrt{y}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "No divide entre 2 el exponente ni de 'x' ni de 'y' al extraer del radical.",
                OptionC = "\\(x^{%n}y^{|18-2*%n|}\\sqrt{y}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No divide entre 2 el exponente de 'y' al extraer del radical.",
                OptionD = "\\(x^{|2*%n|}y^{|9-%n|}\\sqrt{y}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "No divide entre 2 el exponente de 'x' al extraer del radical."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 7 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Selecciona la expresión que representa el resultado de multiplicar: \\[" +
                "\\left(%ma^2+%nb^2\\right)\\left(2b^2-%na^2\\right)" + "\\]",
                OptionA = "\\(|2*%m - %n*%n|a^2b^2+|2*%n|b^4-|%m*%n|a^4\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(|2*%m|a^2b^2-|%n*%n|b^2a^2\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Opera sólo los primeros términos y los segundos términos.",
                OptionC = "\\(|2*%m|a^2b^2+|2*%n|b^4-%na^2\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Opera el primer binomio con el primer término del segundo binomio como si no hubiera un paréntesis.",
                OptionD = "\\(" + "|%m + 2 - %n * %n|a^2b^2 + |2*%n|b^4 - |%m*%n|a^4" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera suma en vez de multiplicación en el primer término."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -1, Maximum = -1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Efectua la resta y elige la expresión que resulta. \\[" +
                "\\dfrac{1}{x+%m} - %n" + "\\]",
                OptionA = "\\(" + "\\dfrac{|1 - %n * %m| - %nx}{x + %m}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "\\dfrac{|1 - %m| - %nx}{x + %m}" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Multiplica un solo término.",
                OptionC = "\\(" + "\\dfrac{|1 + %n * %m| - %nx}{x + %m}" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvido signo al multiplicar el segundo término.",
                OptionD = "\\(" + "\\dfrac{|1 - %n|}{x + %m}" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera numeradroes sin considerar denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -4, Maximum = -1 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza las operaciones indicadas y elige la respuesta: \\[" +
                "(%m + x)^{2}(-1) - (%n - x)(%n + x)" + "\\]",
                OptionA = "\\(" + "|-(%m * %m) - (%n * %n)| - |2*%m|x" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "|-(%m * %m) - (%n * %n)|" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Binomio al cuadrado como cuadrado de términos.",
                OptionC = "\\(" + "2x^{2} + |2*%m|x + |%m * %m - 1 - %n * %n|" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplicación por -1 interpretada como resta,",
                OptionD = "\\(" + "|-(%m * %m) - (%n * %n)| - |2 * %m|x - 2x^{2}" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Olvido cambio de signo en segunda multiplicación."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 5 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "En la expresión \\(" +
                "(x^2 - %m)^2 + x^2(x^2 - %m)" + "\\)" +
                ", factoriza el término \\(" +
                "(x^2 - %m)" + "\\)",
                OptionA = "\\(" + "(x^2 - %m)(2x^2 - %m)" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "2x^4 - %mx^2 + |%m * %m|" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Opera binomio al cuadrado como cuadrado de sus términos.",
                OptionC = "\\(" + "2x^4 - |3 * %m|x^2 + |%m * %m|" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Realiza operaciones en lugar de factorizar.",
                OptionD = "\\(" + "(x^2 - %m)^2(1 + x^2)" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Expresión factorizada pero considerando el témino al cuadrado."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -4, Maximum = -1 });
        }
    }
}

/*
            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Pregunta: \\[" +
                "" + "\\]",
                OptionA = "\\(" + "" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Retro",
                OptionC = "\\(" + "" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Retro",
                OptionD = "\\(" + "" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Retro"
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 7 });

    */
