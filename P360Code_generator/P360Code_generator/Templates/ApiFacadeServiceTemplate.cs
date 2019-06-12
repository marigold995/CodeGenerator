﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace _360Generator.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using _360Generator;
    using _360Generator.Metadata;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ApiFacadeServiceTemplate : ApiFacadeServiceTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\n");
            this.Write("\n");
            this.Write("using _360.Framework.Api.");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module.ModuleName));
            
            #line default
            #line hidden
            this.Write(";\nusing BusinessMap.Client.Rest.Models;\nusing System.Collections.Generic;\n\nnamesp" +
                    "ace _360.Api.Facade.");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(facade));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(module.ModuleName));
            
            #line default
            #line hidden
            this.Write(".Service\n{\n    internal class ");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Service : BusinessMapBaseClient, ISecurityAndITPolicyService\n    {\n        public" +
                    " ");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Service() : base()\n        {\n\n        }\n\n        public IEnumerable<");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto> GetAll() => Execute(() => BusinessMap.Api.");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write(".GetAll());\n\n        public IEnumerable<");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto> Get");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("s(string companyContext) => Execute(() => BusinessMap.Api.");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write(".GetAll");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("sByBuyer(companyContext, null, null));\n\n        public ");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write("Dto GetById(string id) => Execute(() => BusinessMap.Api.");
            
            #line 10 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity));
            
            #line default
            #line hidden
            this.Write(".GetById(id));\n    }\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 12 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"

 private string LowerInitial(string name)
 { return name[0].ToString().ToLowerInvariant() + name.Substring(1);}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\HP\source\repos\Repo1\P360Code_generator\P360Code_generator\Templates\ApiFacadeServiceTemplate.tt"

private global::_360Generator.Metadata.Module _moduleField;

/// <summary>
/// Access the module parameter of the template.
/// </summary>
private global::_360Generator.Metadata.Module module
{
    get
    {
        return this._moduleField;
    }
}

private string _entityField;

/// <summary>
/// Access the entity parameter of the template.
/// </summary>
private string entity
{
    get
    {
        return this._entityField;
    }
}

private global::System.Collections.Generic.List<_360Generator.Metadata.Entity.screenEnum> _screensField;

/// <summary>
/// Access the screens parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<_360Generator.Metadata.Entity.screenEnum> screens
{
    get
    {
        return this._screensField;
    }
}

private global::_360Generator.Metadata.Entity.facadeEnum _facadeField;

/// <summary>
/// Access the facade parameter of the template.
/// </summary>
private global::_360Generator.Metadata.Entity.facadeEnum facade
{
    get
    {
        return this._facadeField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool moduleValueAcquired = false;
if (this.Session.ContainsKey("module"))
{
    this._moduleField = ((global::_360Generator.Metadata.Module)(this.Session["module"]));
    moduleValueAcquired = true;
}
if ((moduleValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("module");
    if ((data != null))
    {
        this._moduleField = ((global::_360Generator.Metadata.Module)(data));
    }
}
bool entityValueAcquired = false;
if (this.Session.ContainsKey("entity"))
{
    this._entityField = ((string)(this.Session["entity"]));
    entityValueAcquired = true;
}
if ((entityValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("entity");
    if ((data != null))
    {
        this._entityField = ((string)(data));
    }
}
bool screensValueAcquired = false;
if (this.Session.ContainsKey("screens"))
{
    this._screensField = ((global::System.Collections.Generic.List<_360Generator.Metadata.Entity.screenEnum>)(this.Session["screens"]));
    screensValueAcquired = true;
}
if ((screensValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("screens");
    if ((data != null))
    {
        this._screensField = ((global::System.Collections.Generic.List<_360Generator.Metadata.Entity.screenEnum>)(data));
    }
}
bool facadeValueAcquired = false;
if (this.Session.ContainsKey("facade"))
{
    this._facadeField = ((global::_360Generator.Metadata.Entity.facadeEnum)(this.Session["facade"]));
    facadeValueAcquired = true;
}
if ((facadeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("facade");
    if ((data != null))
    {
        this._facadeField = ((global::_360Generator.Metadata.Entity.facadeEnum)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class ApiFacadeServiceTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
