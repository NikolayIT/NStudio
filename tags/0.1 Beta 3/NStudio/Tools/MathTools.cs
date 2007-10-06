using System;
using System.Text;
using NStudioInterface;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace NStudio
{
    public partial class MathTools : DockBase
    {
        public MathTools()
        {
            InitializeComponent();
            cboFromBase.SelectedIndex = 0;
            cboToBase.SelectedIndex = 8;
        }
        public override string StatusBarName
        {
            get
            {
                return "MathTools 0.2";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int fromBase = int.Parse(cboFromBase.Text);
                int toBase = int.Parse(cboToBase.Text);
                txtResult.Text = Converter.Convert(fromBase, toBase, txtValue.Text);
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }
        static string Evaluate(string aExpr)
        {
            CodeDomProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler compiler = codeProvider.CreateCompiler();
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
            compilerParams.ReferencedAssemblies.Add("System.Drawing.dll");
            compilerParams.ReferencedAssemblies.Add("System.Xml.dll");
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            StringBuilder code = new StringBuilder();
            code.Append("using System;\n");
            code.Append("namespace Evaluator\n");
            code.Append("{\n");
            code.Append("   public class _Evaluator\n");
            code.Append("   {\n");
            code.Append("       public string Evaluate()\n");
            code.Append("       {\n");
            code.Append("           return (" + aExpr + ").ToString();\n");
            code.Append("       }\n");
            code.Append("   }\n");
            code.Append("}\n");
            CompilerResults cr = compiler.CompileAssemblyFromSource(compilerParams, code.ToString());
            if (cr.Errors.HasErrors)
            {
                StringBuilder error = new StringBuilder();
                error.Append("Error Compiling Expression: ");
                foreach (CompilerError err in cr.Errors)
                {
                    error.AppendFormat("{0}\n", err.ErrorText);
                }
                return error.ToString();
            }
            Assembly a = cr.CompiledAssembly;
            object _Compiled = a.CreateInstance("Evaluator._Evaluator");
            MethodInfo mi = _Compiled.GetType().GetMethod("Evaluate");
            try
            {
                string result = mi.Invoke(_Compiled, null).ToString();
                return result;
            }
            catch (Exception ex)
            {
                return "Error In Code: " + ex.Message;
            }
        }
        void AddExpressionResult(string res, int i)
        {
            if (string.IsNullOrEmpty(res) || res == '\x01'.ToString()) return;
            txtEvalRes.Text += "Expression" + i + ": " + Evaluate(res) + Environment.NewLine;            
        }
        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            txtEvalRes.Text = "";
            int i = 0;
            StringBuilder line = new StringBuilder();
            string workwith = txtExpression.Text.Replace(Environment.NewLine, "\x01");
            foreach (char c in workwith)
            {
                if (c == '\x01')
                {
                    i++;
                    AddExpressionResult(line.ToString(), i);
                    line = new StringBuilder();
                }
                else line.Append(c);
            }
            i++;
            AddExpressionResult(line.ToString(), i);
            line = null;
        }
    }
}