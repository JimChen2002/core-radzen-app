#pragma checksum "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a71af1389bedf4b9e7f25f3b0156faf0dfdd497"
// <auto-generated/>
#pragma warning disable 1591
namespace CoreRadzen.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#line 6 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 7 "C:\JIM\CORE-RADZEN\server\_Imports.razor"
using CoreRadzen.Shared;

#line default
#line hidden
#line 5 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
using Radzen;

#line default
#line hidden
#line 6 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
using Radzen.Blazor;

#line default
#line hidden
#line 7 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
using CoreRadzen.Models.Core;

#line default
#line hidden
#line 8 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
using CoreRadzen.Models;

#line default
#line hidden
#line 9 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 10 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
           [Authorize]

#line default
#line hidden
    [global::Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/add-tbl-core-attendance/{tblEvent_ID}")]
    public partial class AddTblCoreAttendance : CoreRadzen.Pages.AddTblCoreAttendanceComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(3, "\n    ");
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "row");
                __builder2.AddMarkupContent(6, "\n      ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "col-md-12");
                __builder2.AddMarkupContent(9, "\n        ");
                __builder2.OpenComponent<global::Radzen.Blazor.RadzenTemplateForm<CoreRadzen.Models.Core.TblCoreAttendance>>(10);
                __builder2.AddAttribute(11, "Data", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<CoreRadzen.Models.Core.TblCoreAttendance>(
#line 15 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                   tblcoreattendance

#line default
#line hidden
                ));
                __builder2.AddAttribute(12, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#line 15 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                 tblcoreattendance != null

#line default
#line hidden
                ));
                __builder2.AddAttribute(13, "Submit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<CoreRadzen.Models.Core.TblCoreAttendance>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<CoreRadzen.Models.Core.TblCoreAttendance>(this, 
#line 15 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                                                                                                       Form0Submit

#line default
#line hidden
                )));
                __builder2.AddAttribute(14, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.AddMarkupContent(15, "\n            ");
                    __builder3.OpenElement(16, "div");
                    __builder3.AddAttribute(17, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(18, "class", "row");
                    __builder3.AddMarkupContent(19, "\n              ");
                    __builder3.OpenElement(20, "div");
                    __builder3.AddAttribute(21, "class", "col-md-3");
                    __builder3.AddMarkupContent(22, "\n                ");
                    __builder3.OpenComponent<global::Radzen.Blazor.RadzenLabel>(23);
                    __builder3.AddAttribute(24, "Text", "Tbl Ad User");
                    __builder3.AddAttribute(25, "Component", "tblADUser_ID");
                    __builder3.AddAttribute(26, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(27, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(28, "\n              ");
                    __builder3.OpenElement(29, "div");
                    __builder3.AddAttribute(30, "class", "col-md-9");
                    __builder3.AddMarkupContent(31, "\n                ");
                    global::__Blazor.CoreRadzen.Pages.AddTblCoreAttendance.TypeInference.CreateRadzenDropDown_0(__builder3, 32, 33, 
#line 23 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                       getTblAdUsersResult

#line default
#line hidden
                    , 34, "UserName", 35, "tblADUser_ID", 36, "Choose TblAdUser", 37, "display: block; width: 100%", 38, "TblADUser_ID", 39, 
#line 23 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                                                                                                                                                   tblcoreattendance.tblADUser_ID

#line default
#line hidden
                    , 40, global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => tblcoreattendance.tblADUser_ID = __value, tblcoreattendance.tblADUser_ID)), 41, () => tblcoreattendance.tblADUser_ID);
                    __builder3.AddMarkupContent(42, "\n                ");
                    __builder3.OpenComponent<global::Radzen.Blazor.RadzenRequiredValidator>(43);
                    __builder3.AddAttribute(44, "Component", "TblADUser_ID");
                    __builder3.AddAttribute(45, "Text", "tblADUser_ID is required");
                    __builder3.AddAttribute(46, "style", "position: absolute");
                    __builder3.AddAttribute(47, "DefaultValue", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#line 25 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                                                                                           0

#line default
#line hidden
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(48, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(49, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(50, "\n            ");
                    __builder3.OpenElement(51, "div");
                    __builder3.AddAttribute(52, "class", "row");
                    __builder3.AddMarkupContent(53, "\n              ");
                    __builder3.OpenElement(54, "div");
                    __builder3.AddAttribute(55, "class", "col offset-sm-3");
                    __builder3.AddMarkupContent(56, "\n                ");
                    __builder3.OpenComponent<global::Radzen.Blazor.RadzenButton>(57);
                    __builder3.AddAttribute(58, "ButtonType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Radzen.ButtonType>(
#line 31 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                          ButtonType.Submit

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(59, "Icon", "save");
                    __builder3.AddAttribute(60, "Text", "Save");
                    __builder3.AddAttribute(61, "ButtonStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Radzen.ButtonStyle>(
#line 31 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                                                  ButtonStyle.Primary

#line default
#line hidden
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(62, "\n                ");
                    __builder3.OpenComponent<global::Radzen.Blazor.RadzenButton>(63);
                    __builder3.AddAttribute(64, "ButtonStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Radzen.ButtonStyle>(
#line 33 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                           ButtonStyle.Light

#line default
#line hidden
                    ));
                    __builder3.AddAttribute(65, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(66, "Text", "Cancel");
                    __builder3.AddAttribute(67, "Click", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 33 "C:\JIM\CORE-RADZEN\server\Pages\AddTblCoreAttendance.razor"
                                                                                                              Button2Click

#line default
#line hidden
                    )));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(68, "\n              ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(69, "\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(70, "\n          ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(71, "\n      ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(73, "\n  ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.CoreRadzen.Pages.AddTblCoreAttendance
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenDropDown_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.IEnumerable __arg0, int __seq1, global::System.String __arg1, int __seq2, global::System.String __arg2, int __seq3, global::System.String __arg3, int __seq4, global::System.Object __arg4, int __seq5, global::System.String __arg5, int __seq6, global::System.Object __arg6, int __seq7, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg7, int __seq8, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg8)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenDropDown<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "TextProperty", __arg1);
        __builder.AddAttribute(__seq2, "ValueProperty", __arg2);
        __builder.AddAttribute(__seq3, "Placeholder", __arg3);
        __builder.AddAttribute(__seq4, "style", __arg4);
        __builder.AddAttribute(__seq5, "Name", __arg5);
        __builder.AddAttribute(__seq6, "Value", __arg6);
        __builder.AddAttribute(__seq7, "ValueChanged", __arg7);
        __builder.AddAttribute(__seq8, "ValueExpression", __arg8);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
