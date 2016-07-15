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
                Description =  "Factoriza el término \\((x^2 - %m)\\) en la expresión \\[" +
                "(x^2 - %m)^2 + x^2(x^2 - %m)" + "\\]",
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

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Despeja 'y' de la ecuación: \\[" +
                "%nx-|%n-1|y+|%n+2|=0" + "\\]",
                OptionA = "\\(" + "y=\\dfrac{%nx}{|%n-1|} + \\dfrac{|%n+2|}{|%n-1|}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "y=\\dfrac{%nx}{|%n-1|} + |%n+2|" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Falta pasar dividiendo en ambaos términos.",
                OptionC = "\\(" + "y=-\\dfrac{%nx}{|%n-1|} - \\dfrac{|%n+2|}{|%n-1|}" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Signo al despejar.",
                OptionD = "\\(" + "y=-\\dfrac{%nx}{|%n-1|} - |%n+2|" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Signo al despejar y falta dividir ambos términos."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguiente opciones elige la que expresa correctamente el despeje de 'y' en la expresión: \\[" +
                "%m + %ny -x = 1" + "\\]",
                OptionA = "\\(" + "y = \\dfrac{x + |1 - %m|}{%n}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "y=\\dfrac{x+|1+%m|}{%n}" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Signo al pasar la constante al otro lado de la igualdad",
                OptionC = "\\(" + "y= \\dfrac{x+1}{%n}" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Anula la constante del lado izquierdo.",
                OptionD = "\\(" + "y= \\dfrac{x-%m}{%n}" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Anula la constante del lado derecho."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Elige la expresión que se obitene al sustituir \\(y=x-2%n\\) en la expresión: \\[" +
                "x+y+%n=0" + "\\]",
                OptionA = "\\(" + "2x-%n=0" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "2x-|2*%n|=0" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Anula la constante.",
                OptionC = "\\(" + "x-%n=0" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Anula la primer 'x' al sustituir.",
                OptionD = "\\(" + "x-|2*%n| =0" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Anula la primer 'x' y la constante."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 7 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Factoriza \\(x^2\\) de la siguiente expresión: \\[" +
                "%mx^2+%nx^3" + "\\]",
                OptionA = "\\(" + "x^2(%m+%nx)" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "%mx(1+%nx)" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Se enfoca en primer término completo.",
                OptionC = "\\(" + "x^2%m + x^2%nx" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Expresión cierta pero no factoriza.",
                OptionD = "\\(" + "(%mx^2+%nx^2)x" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Separa x para dejar x^2."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Elige la expresión que resulta ser cierta cuando se trabajca alebraícamente la expresión: \\[" +
                "\\dfrac{1}{|2*%n|}x + \\dfrac{1}{|2*%n+1|} = 0" + "\\]",
                OptionA = "\\(" + "|2*%n+1|x+2%n=0" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "|2*%n+1|x+2%n=1" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Considerar igualdad a 0 como igual a 1.",
                OptionC = "\\(" + "|2*%n+1|x+2%n=|(2*%n)*(2*%n+1)|" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Considerar 0=1 en el proceso.",
                OptionD = "\\(" + "|2*%n|x+|2*%n+1|=|(2*%n)*(2*%n+1)|" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Error al operar con el común denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -5, Maximum = -2 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Despeja \\(x\\) de la expresión: \\[" +
                "%mx^2-|2*%m|=0" + "\\]",
                OptionA = "\\(" + "x=\\pm\\sqrt{2}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "x=\\pm\\sqrt{|3*%m|}" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Pasa m sumando a 2m.",
                OptionC = "\\(" + "x=\\pm\\sqrt{|2*%m|}" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olivdo m en x^2.",
                OptionD = "\\(" + "x=\\pm|2*%m|" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Retro"
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Encuentra las soluciones de la ecuación cuadrática siguiente: \\[" +
                "\\dfrac{%nx^2}{%m} - \\dfrac{x}{|%n+2|} =0" + "\\]",
                OptionA = "\\(x=0\\) y \\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Cancela x sin considerar que x=0 es solución.",
                OptionC = "\\(x=0\\) y \\(x=\\dfrac{%n}{|%m*(%n+2)|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Despeja mal al pasar números.",
                OptionD = "\\(x^2=\\dfrac{%m}{%n}\\) y \\(x=|%n+2|\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Retro"
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Resuelve la ecuación cuadrática y elige su solución: \\[" +
                "|%n*%n|x^2-|%m*%m|=0" + "\\]",
                OptionA = "\\(x=\\dfrac{%m}{%n}\\) y \\(x=\\dfrac{-%m}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(x=\\dfrac{%n}{%m}\\) y \\(x=\\dfrac{-%n}{%m}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Despeje aml realizado.",
                OptionC = "\\(x=\\dfrac{%m}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No considera ambas opciones de signo.",
                OptionD = "\\(x^2=\\dfrac{|%m*%m|}{|%n*%n|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "No resuelve el despeje."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes pxpresiones cuadráticas, elige la que toma valores positivos siempre, inteprrendientemente del valor designado a 'x'.",
                OptionA = "\\(" + "%nx^2+%m" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "|%n*%n|x^2-%m" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Se prejuicia observando los números.",
                OptionC = "\\(" + "x^2 + %mx + 1" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Se prejuiciia con los signos positivos en la expresión.",
                OptionD = "\\(" + "x^2 + %mx -1" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Se prejuicia evaluando en enteros positivos."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 5 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Encuentra todos los valores de x que satisfacen la ecuación: \\[" +
                "\\dfrac{%n-x^2}{x^2}=0" + "\\]",
                OptionA = "\\(" + "x=\\pm\\sqrt{%n}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "x=\\pm\\sqrt{\\dfrac{1}{%n}}" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Despeja mal al pasar dividiendo.",
                OptionC = "\\(" + "x=\\pm%n" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No despeja el cuadrado.",
                OptionD = "\\(" + "x=\\pm\\sqrt{\\dfrac{%n}{2}}" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Pasa x^2 multiplicando por 1 en vez de por 0."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 11, Maximum = 11 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 13, Maximum = 13 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Resuelve la ecuación cuadrática y elige sus soluciones: \\[" +
                "x^2 - %nx - 1 = 0" + "\\]",
                OptionA = "\\(x=\\dfrac{%n+\\sqrt{|%n*%n+4|}}{2}\\), \\(x=\\dfrac{%n-\\sqrt{|%n*%n+4|}}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(x=1\\), \\(x=%n\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Opera x^2-nx=1 igualando los factores a 1.",
                OptionC = "\\(x=\\sqrt{%nx+1}\\), \\(x=-\\sqrt{%nx+1}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Despeja de x^2 sin condierar x.",
                OptionD = "No tiene solución",
                OptionDCorrect = false,
                OptionDFeedback = "No puede resolverlo."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 7 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "En la sigueinte ecuación sustituye \\(y=\\dfrac{1}{%n}\\) y obtén el valor de x: \\[" +
                "|2*%n| - %nx + \\dfrac{y}{%n} = 0" + "\\]",
                OptionA = "\\(" + "x=\\dfrac{|2*%n*%n*%n+1|}{|%n*%n*%n|}" + "\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(" + "x=\\dfrac{|2*%n-1|}{%n}" + "\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Al sustituir opera como y=n",
                OptionC = "\\(" + "x=-\\dfrac{1}{|%n*%n*%n|}" + "\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Resta los 2 primeros términos como si tuvieran x ambos.",
                OptionD = "\\(" + "x=-\\dfrac{1}{%n}" + "\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Resta 2 primeros términos y sustituye y=n."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
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
