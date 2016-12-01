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
                Description =
                "Las fórmulas son maneras concretas de representar algo que cumplen los números.\n" +
                "Son expresiones algebraicas donde podemos encontrar letras, números y operaciones que los conectan.\n" +
                "Con las fórmulas somos capaces de expresar comportamientos y realizar procedimientos de una manera general\n",
                Active = true
            });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las opciones dadas abajo, elige la que es equivalente a la siguiente: \\[" +
                "\\left ( x^{2} + |%n*%n| \\right )^{-2}\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{\\left ( x^{2} + |%n*%n|\\right )^{2}}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{x^{4} + |%n*%n|^{2}}\\)", IsCorrect = false, Feedback = "Realiza suma de los cuadrados de cada término", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(-\\left ( x^{2} + |%n*%n|\\right )^{2}\\)", IsCorrect = false, Feedback = "Interpretación incorrecta de signo negativo en exponente.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^{-4} + |%n*%n|^{-2}\\)", IsCorrect = false, Feedback = "Distribuye el exponente en cada término.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguiente opciones elige la que es equivalente a la expresión algebraica. \\[" +
                "\\sqrt{x^{2} + |%n*%n|}\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(\\left (x^{2} + |%n*%n|\\right )^{1/2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\sqrt{\\left (x+%n\\right )\\left (x-%n\\right )}\\)", IsCorrect = false, Feedback = "Aplica producto notable de diferencia de cuadrados en una suma de cuadrados", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x+%n\\)", IsCorrect = false, Feedback = "Distribuye el radical en cada término y cancela el cuadrado con el radical.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\sqrt{\\left (x+%n\\right )^{2}}\\)", IsCorrect = false, Feedback = "Producto notable de binomio al cuadrado confundido con suma de cuadrados de cada término.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Simplifica la expresión dada en seguida y selecciona la opción que le corresponde \\[" +
                "\\left (\\dfrac{%nab^{|%n+1|}}{b^{%n}}\\right )^{-1}\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{%nab}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(-%nab\\)", IsCorrect = false, Feedback = "Exponente negativo confundido con cambio de signo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{%nab}{1}\\)", IsCorrect = false, Feedback = "No opera el exponente negativo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{ab}\\)", IsCorrect = false, Feedback = "Opera el exponente negativo sólo a las letras y no a los números.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Simplifica la expresión con radicales dada enseguida y elcoge la opción que la muestra. \\[" +
                "\\sqrt{x^{|2*%n|}y^{|19-2*%n|}}\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x^{%n}y^{|9-%n|}\\sqrt{y}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^{|2*%n|}y^{|18-2*%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente ni de 'x' ni de 'y' al extraer del radical.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^{%n}y^{|18-2*%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente de 'y' al extraer del radical.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^{|2*%n|}y^{|9-%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente de 'x' al extraer del radical.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 7 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Selecciona la expresión que representa el resultado de multiplicar: \\[" +
                "\\left(%ma^2+%nb^2\\right)\\left(2b^2-%na^2\\right)\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(|2*%m - %n*%n|a^2b^2+|2*%n|b^4-|%m*%n|a^4\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|2*%m|a^2b^2-|%n*%n|b^2a^2\\)", IsCorrect = false, Feedback = "Opera sólo los primeros términos y los segundos términos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|2*%m|a^2b^2+|2*%n|b^4-%na^2\\)", IsCorrect = false, Feedback = "Opera el primer binomio con el primer término del segundo binomio como si no hubiera un paréntesis.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|%m + 2 - %n * %n|a^2b^2 + |2*%n|b^4 - |%m*%n|a^4\\)", IsCorrect = false, Feedback = "Opera suma en vez de multiplicación en el primer término.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -1, Maximum = -1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Efectua la resta y elige la expresión que resulta. \\[" +
                "\\dfrac{1}{x+%m} - %n\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %n * %m| - %nx}{x + %m}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %m| - %nx}{x + %m}\\)", IsCorrect = false, Feedback = "Multiplica un solo término.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 + %n * %m| - %nx}{x + %m}\\)", IsCorrect = false, Feedback = "Olvido signo al multiplicar el segundo término.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %n|}{x + %m}\\)", IsCorrect = false, Feedback = "Opera numeradroes sin considerar denominador.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -4, Maximum = -1 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Realiza las operaciones indicadas y elige la respuesta: \\[" +
                "(%m + x)^{2}(-1) - (%n - x)(%n + x)\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)| - |2*%m|x\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)|\\)", IsCorrect = false, Feedback = "Binomio al cuadrado como cuadrado de términos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(2x^{2} + |2*%m|x + |%m * %m - 1 - %n * %n|\\)", IsCorrect = false, Feedback = "Multiplicación por -1 interpretada como resta.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)| - |2 * %m|x - 2x^{2}\\)", IsCorrect = false, Feedback = "Olvido cambio de signo en segunda multiplicación.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 3 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 5 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description =  "Factoriza el término \\((x^2 - %m)\\) en la expresión \\[" +
                "(x^2 - %m)^2 + x^2(x^2 - %m)\\]"
            });
            Options.Add(new QuestionOption { Description = "\\((x^2 - %m)(2x^2 - %m)\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(2x^4 - %mx^2 + |%m * %m|\\)", IsCorrect = false, Feedback = "Opera binomio al cuadrado como cuadrado de sus términos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(2x^4 - |3 * %m|x^2 + |%m * %m|\\)", IsCorrect = false, Feedback = "Realiza operaciones en lugar de factorizar.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\((x^2 - %m)^2(1 + x^2)\\)", IsCorrect = false, Feedback = "Expresión factorizada pero considerando el témino al cuadrado.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = -4, Maximum = -1 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Despeja 'y' de la ecuación: \\[" +
                "%nx-|%n-1|y+|%n+2|=0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(y=\\dfrac{%nx}{|%n-1|} + \\dfrac{|%n+2|}{|%n-1|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y=\\dfrac{%nx}{|%n-1|} + |%n+2|\\)", IsCorrect = false, Feedback = "Falta pasar dividiendo en ambaos términos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y=-\\dfrac{%nx}{|%n-1|} - \\dfrac{|%n+2|}{|%n-1|}\\)", IsCorrect = false, Feedback = "Signo al despejar.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y=-\\dfrac{%nx}{|%n-1|} - |%n+2|\\)", IsCorrect = false, Feedback = "Signo al despejar y falta dividir ambos términos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguiente opciones elige la que expresa correctamente el despeje de 'y' en la expresión: \\[" +
                "%m + %ny -x = 1\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(y = \\dfrac{x + |1 - %m|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y=\\dfrac{x+|1+%m|}{%n}\\)", IsCorrect = false, Feedback = "Signo al pasar la constante al otro lado de la igualdad", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y= \\dfrac{x+1}{%n}\\)", IsCorrect = false, Feedback = "Anula la constante del lado izquierdo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(y= \\dfrac{x-%m}{%n}\\)", IsCorrect = false, Feedback = "Anula la constante del lado derecho.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 1, Maximum = 1 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Elige la expresión que se obitene al sustituir \\(y=x-2%n\\) en la expresión: \\[" +
                "x+y+%n=0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(2x-%n=0\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(2x-|2*%n|=0\\)", IsCorrect = false, Feedback = "Anula la constante.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x -% n = 0\\)", IsCorrect = false, Feedback = "Anula la primer 'x' al sustituir.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x-|2*%n| =0\\)", IsCorrect = false, Feedback = "Anula la primer 'x' y la constante.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 1, Maximum = 7 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Factoriza \\(x^2\\) de la siguiente expresión: \\[" +
                "%mx^2+%nx^3\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x^2(%m+%nx)\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(%mx(1+%nx)\\)", IsCorrect = false, Feedback = "Se enfoca en primer término completo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^2%m + x^2%nx\\)", IsCorrect = false, Feedback = "Expresión cierta pero no factoriza.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\((%mx^2+%nx^2)x\\)", IsCorrect = false, Feedback = "Separa x para dejar x^2.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Elige la expresión que resulta ser cierta cuando se trabajca alebraícamente la expresión: \\[" +
                "\\dfrac{1}{|2*%n|}x + \\dfrac{1}{|2*%n+1|} = 0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=0\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=1\\)", IsCorrect = false, Feedback = "Considerar igualdad a 0 como igual a 1.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=|(2*%n)*(2*%n+1)|\\)", IsCorrect = false, Feedback = "Considerar 0=1 en el proceso.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|2*%n|x+|2*%n+1|=|(2*%n)*(2*%n+1)|\\)", IsCorrect = false, Feedback = "Error al operar con el común denominador.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = -5, Maximum = -2 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Despeja \\(x\\) de la expresión: \\[" +
                "%mx^2-|2*%m|=0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{|3*%m|}\\)", IsCorrect = false, Feedback = "Pasa m sumando a 2m.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{|2*%m|}\\)", IsCorrect = false, Feedback = "Olivdo m en x^2.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm|2*%m|\\)", IsCorrect = false, Feedback = "Retro", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 9 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Encuentra las soluciones de la ecuación cuadrática siguiente: \\[" +
                "\\dfrac{%nx^2}{%m} - \\dfrac{x}{|%n+2|} =0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=0\\) y \\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)", IsCorrect = false, Feedback = "Cancela x sin considerar que x=0 es solución.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=0\\) y \\(x=\\dfrac{%n}{|%m*(%n+2)|}\\)", IsCorrect = false, Feedback = "Despeja mal al pasar números.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^2=\\dfrac{%m}{%n}\\) y \\(x=|%n+2|\\)", IsCorrect = false, Feedback = "Retro", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Resuelve la ecuación cuadrática y elige su solución: \\[" +
                "|%n*%n|x^2-|%m*%m|=0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{%n}\\) y \\(x=\\dfrac{-%m}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%n}{%m}\\) y \\(x=\\dfrac{-%n}{%m}\\)", IsCorrect = false, Feedback = "Despeje aml realizado.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{%n}\\)", IsCorrect = false, Feedback = "No considera ambas opciones de signo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^2=\\dfrac{|%m*%m|}{|%n*%n|}\\)", IsCorrect = false, Feedback = "No resuelve el despeje.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 9, Maximum = 9 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Entre las siguientes pxpresiones cuadráticas, elige la que toma valores positivos siempre, inteprrendientemente del valor designado a 'x'."
            });
            Options.Add(new QuestionOption { Description = "\\(%nx^2+%m\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(|%n*%n|x^2-%m\\)", IsCorrect = false, Feedback = "Se prejuicia observando los números.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^2 + %mx + 1\\)", IsCorrect = false, Feedback = "Se prejuiciia con los signos positivos en la expresión.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x^2 + %mx -1\\)", IsCorrect = false, Feedback = "Se prejuicia evaluando en enteros positivos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "m" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "m", ID = ++RangeCounter, Minimum = 3, Maximum = 5 });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 2 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 4, Maximum = 4 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 6, Maximum = 6 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 8, Maximum = 8 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 10, Maximum = 10 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Encuentra todos los valores de x que satisfacen la ecuación: \\[" +
                "\\dfrac{%n-x^2}{x^2}=0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{\\dfrac{1}{%n}}\\)", IsCorrect = false, Feedback = "Despeja mal al pasar dividiendo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm%n\\)", IsCorrect = false, Feedback = "No despeja el cuadrado.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{\\dfrac{%n}{2}}\\)", IsCorrect = false, Feedback = "Pasa x^2 multiplicando por 1 en vez de por 0.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 3, Maximum = 3 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 5, Maximum = 5 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 7, Maximum = 7 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 11, Maximum = 11 });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 13, Maximum = 13 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "Resuelve la ecuación cuadrática y elige sus soluciones: \\[" +
                "x^2 - %nx - 1 = 0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%n+\\sqrt{|%n*%n+4|}}{2}\\), \\(x=\\dfrac{%n-\\sqrt{|%n*%n+4|}}{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=1\\), \\(x=%n\\)", IsCorrect = false, Feedback = "Opera x^2-nx=1 igualando los factores a 1.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\sqrt{%nx+1}\\), \\(x=-\\sqrt{%nx+1}\\)", IsCorrect = false, Feedback = "Despeja de x^2 sin condierar x.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "No tiene solución", IsCorrect = false, Feedback = "No puede resolverlo.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 7 });

            Questions.Add(new SingleSelectionQuestion
            {
                Id = ++QuestionCounter,
                ExamID = ExamCounter,
                Description = "En la sigueinte ecuación sustituye \\(y=\\dfrac{1}{%n}\\) y obtén el valor de x: \\[" +
                "|2*%n| - %nx + \\dfrac{y}{%n} = 0\\]"
            });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{|2*%n*%n*%n+1|}{|%n*%n*%n|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=\\dfrac{|2*%n-1|}{%n}\\)", IsCorrect = false, Feedback = "Al sustituir opera como y=n", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=-\\dfrac{1}{|%n*%n*%n|}\\)", IsCorrect = false, Feedback = "Resta los 2 primeros términos como si tuvieran x ambos.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Options.Add(new QuestionOption { Description = "\\(x=-\\dfrac{1}{%n}\\)", IsCorrect = false, Feedback = "Resta 2 primeros términos y sustituye y=n.", Id = ++OptionCounter, QuestionId = QuestionCounter });
            Variables.Add(new Variable { QuestionId = QuestionCounter, Symbol = "n" });
            Ranges.Add(new Range { QuestionId = QuestionCounter, Symbol = "n", ID = ++RangeCounter, Minimum = 2, Maximum = 5 });
        }
    }
}