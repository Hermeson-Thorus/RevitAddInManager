﻿using System.Collections.Generic;
using System.Windows;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitElementBipChecker.Model;
using RevitElementBipChecker.View;

namespace RevitElementBipChecker.Command;


/// <summary>
/// Compare Two Element with parameter instance different
/// </summary>
[Transaction(TransactionMode.Manual)]
public class CompareTwoEleCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIApplication uiapp = commandData.Application;
        UIDocument uidoc = uiapp.ActiveUIDocument;
        Document doc = uidoc.Document;
        Reference r1 = uidoc.Selection.PickObject(ObjectType.Element,"Select first element");
        Element element1 = doc.GetElement(r1);
        Reference r2 = uidoc.Selection.PickObject(ObjectType.Element,"Select second element");
        Element element2 = doc.GetElement(r2);
        FrmCompareBip frmCompareBip = new FrmCompareBip(element1,element2);
     
        frmCompareBip.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        frmCompareBip.SetRevitAsWindowOwner();
        frmCompareBip.Show();
        return Result.Succeeded;
    }
}