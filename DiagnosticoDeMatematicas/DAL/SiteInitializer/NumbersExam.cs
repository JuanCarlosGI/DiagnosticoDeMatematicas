namespace DiagnosticoDeMatematicas.DAL
{
    using Models;

    public partial class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        private void NumbersExam()
        {
            Exams.Add(new Exam
            {
                ID = ++ExamCounter,
                Name = "Números",
                Description = 
                "Los números son símbolos.\n" +
                "Representan una cantidad de cosas o bien la medida de algo.\n" +
                "Piensa por ejemplo en los habitantes en México o en su área territorial.\n" +
                "Con los números podemos realizar operaciones aritméticas que nos concretan acciones que podemos hacer con lo que representan.\n" +
                "Piensa en separar la cantidad de jóvenes de la de niños, o bien repartir un territorio equitativamente.\n" +
                "Este diagnóstico te permitirá apreciar tu dominio del manejo de los números.\n",
                Active = true
            });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la siguiente operación aritmétca y elige la opción con la respuesta.\\[" +
                "%n+\\frac{|%n-1|}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|%n*%n+%n-1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|2*%n-1|}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(\\dfrac{|%n-1|}{1}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancela numerador con denominador.",
                OptionD = "\\(\\dfrac{|2*%n-1|}{|%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y suma denominadores."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 12 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación aritmética y elige la opción que muestra el resultado. \\[" +
                "\\dfrac{1}{%n} - \\dfrac{%n}{|%n+1|}" + "\\]",
                OptionA = "\\(\\dfrac{|1+%n-%n*%n|}{|%n*%n+%n|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|1-%n|}{|%n*%n+%n|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta numeradores y multiplica denominadores.",
                OptionC = "\\(-\\dfrac{1}{|%n+1|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancela numerador con denominador (como un producto).",
                OptionD = "\\(\\dfrac{|1-%n|}{|2*%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Resta numeradores y suma denominadores"
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 12 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación aritmética indicada y escoge la opción con su resultado. \\[" +
                "\\left ( \\dfrac{1}{%n} \\right )\\left ( \\dfrac{|3*%n|}{13} \\right )" + "\\]",
                OptionA = "\\(\\dfrac{3}{13}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|3*%n+1|}{|%n+13|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y suma denominadores",
                OptionC = "\\(\\dfrac{13}{|3*%n*%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cruza productos como si fuese división.",
                OptionD = "\\(\\dfrac{|3*%n+1|}{|13*%n|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y multiplica denominadores."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 11 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación señalada y elige la opción que meustra el resultado correcto. \\[" +
                "\\left ( %n \\sqrt{%n} \\right )^{2}" + "\\]",
                OptionA = "\\(|%n*%n*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(|%n*%n|\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Olvida elevar al cuadrado al valor libre",
                OptionC = "\\(|%n*%n|\\sqrt{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvida elevar al cuadrado el radical.",
                OptionD = "\\(\\sqrt{|%n*%n*%n|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Realiza operación dentro del radical."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y selecciona su resultado. \\[" +
                "1 + \\dfrac{1}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|%n+1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{2}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(\\dfrac{2}{|1+%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y suma denominadores.",
                OptionD = "\\(\\dfrac{%n}{|%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confunde posición de numerador y denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación indicada y selecciona la respuesta correcta. \\[" +
                "%n - \\dfrac{1}{2}" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)-1|}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n-1|}{2}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(-\\dfrac{%n}{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica en vez de sumar.",
                OptionD = "\\(\\dfrac{|%n+1|}{2}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y deja denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y escoge la opción con la respuesta. \\[" +
                "\\left(\\dfrac{3}{\\sqrt{%n}}\\right)^2" + "\\]",
                OptionA = "\\(\\dfrac{9}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{6}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confunde elvar al cuadrado con multiplicar por 2.",
                OptionC = "\\(\\dfrac{3}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvidó elevar al cuadrado el numerador.",
                OptionD = "\\(\\left(\\dfrac{3\\sqrt{%n}}{%n}\\right)^2\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Reacción de \"racionalizar\"."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 11 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 13, Maximum = 14 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta. \\[" +
                "\\dfrac{%n}{|2*%n|} + \\dfrac{|2*%n|}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{5}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(1\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y suma denominadores o bien cancela como si fuera producto.",
                OptionC = "\\(\\dfrac{3}{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y deja el común denominador",
                OptionD = "\\(\\dfrac{1}{4}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación cruzada como división."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación indicada y escoge el resultado. \\[" +
                "\\dfrac{1}{3} + %n" + "\\]",
                OptionA = "\\(\\dfrac{|(3*%n)+1|}{3}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{%n}{3}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Multiplica en vez de sumar",
                OptionC = "\\(\\dfrac{|%n+1|}{3}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionD = "\\(\\dfrac{|%n+3|}{3}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numerador con denominador (cruzado) y deja el mismo denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 8 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "2-\\dfrac{1}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)-1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{-2\\,\\,\\,\\,}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Multiplica en vez de sumar",
                OptionC = "\\(\\dfrac{1}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Resta numeradores y deja el mismo denominador.",
                OptionD = "\\(\\dfrac{|(2*%n)+1|}{%n}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma en vez de restar."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,%n\\,\\,\\,\\,}{\\dfrac{1}{%n}}" + "\\]",
                OptionA = "\\(|%n*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{|%n*%n|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Colocación producto de extremos y medios",
                OptionC = "\\(1\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancelación como su fuera producto y no división.",
                OptionD = "\\(|2*%n|\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión de elevar al cuadrado con multiplicar por 2."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}{\\dfrac{1}{|%n+1|}}" + "\\]",
                OptionA = "\\(\\dfrac{|%n+1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n|}{|%n+1|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Colocación de producto de extremos y medios o bien cancelar el 1.",
                OptionC = "\\(\\dfrac{1}{|(%n*%n)+%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Operación como producto.",
                OptionD = "\\(\\dfrac{|(%n*%n)+%n|}{1}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación como producto y c9olocación en posición contraria."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 8 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "\\left(\\dfrac{%n}{3}\\right)\\left(\\dfrac{1}{|2*%n|}\\right)" + "\\]",
                OptionA = "\\(\\dfrac{1}{6}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{5}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Sumar denominadores en vez de multiplicar.",
                OptionC = "\\(\\dfrac{|2*%n*%n|}{3}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica cruzado, como división.",
                OptionD = "\\(\\dfrac{|%n+1|}{|3+(2*%n)|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y denominadores."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación indicada y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{%n}{|%n+1|}\\,\\,\\,\\,}{2}" + "\\]",
                OptionA = "\\(\\dfrac{%n}{|(2*%n)+2|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|2*%n|}{|%n+1|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión de extremos y medios.",
                OptionC = "\\(\\dfrac{|(2*%n)+2|}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Colocación de producto extremos y medios.",
                OptionD = "\\(\\dfrac{%n}{|%n+3|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Al multiplicar realiza suma."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{1}{2}\\left(|(2*%n)+1|\\right)" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)+1|}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|(2*%n)+2|}{2}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores.",
                OptionC = "\\(\\dfrac{1}{|(4*%n)+2|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica con efecto cruzado.",
                OptionD = "\\(\\dfrac{|(2*%n)+2|}{3}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y denominadores."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\left(\\sqrt{%n}\\right)^3" + "\\]",
                OptionA = "\\(%n\\sqrt{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\left(|%n*%n|\\right)\\left(%n\\right)\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Olvido de radical.",
                OptionC = "\\(3\\sqrt{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión de exponente con producto.",
                OptionD = "\\(|%n*%n|\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera al cuadrado y no al cubo."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 11 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n} - %n" + "\\]",
                OptionA = "\\(\\dfrac{|1-(%n*%n)|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|1-%n|}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta de numeradores",
                OptionC = "\\(\\dfrac{|1-(2*%n)|}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión elevar al cuadrado con multiplicar por 2.",
                OptionD = "\\(-\\dfrac{|%n*%n|}{%n}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación cruzada."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige su respuesta. \\[" +
                "%n-\\dfrac{1}{%m}" + "\\]",
                OptionA = "\\(\\dfrac{|(%n*%m) - 1|}{%m}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n-1|}{%m}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta de numeradores",
                OptionC = "\\(\\dfrac{|(%n*%m)|}{%m}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvido de resta de 1",
                OptionD = "\\(-\\dfrac{%n}{%m}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión con multiplicación."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n}-\\dfrac{%n}{%m}" + "\\]",
                OptionA = "\\(\\dfrac{|%m-(%n*%n)|}{|%m*%n|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(-\\dfrac{1}{%m}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión con multiplicación.",
                OptionC = "\\(\\dfrac{|1-%n|}{|%n-%m|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Resta de numeradores y denominadores.",
                OptionD = "\\(\\dfrac{|1-%n|}{|%n*%m|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Resta numeradores y común denominador."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new Question
            {
                ID = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza la operación y elige la respuesta correspondiente. \\[" +
                "\\dfrac{%m}{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}" + "\\]",
                OptionA = "\\(|%m*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{%m}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión extremos y medios.",
                OptionC = "\\(\\dfrac{%n}{%m}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión extremos y medios.",
                OptionD = "\\(\\dfrac{1}{|%n*%m|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión extremos y medios."
            });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });
            Variables.Add(new Variable { QuestionID = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });
        }
    }
}