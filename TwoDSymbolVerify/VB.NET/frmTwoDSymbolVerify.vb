'*******************************************************************************
' Copyright (C) 2004 Cognex Corporation
'
' Subject to Cognex Corporation's terms and conditions and license agreement,
' you are authorized to use and modify this source code in any way you find
' useful, provided the Software and/or the modified Software is used solely in
' conjunction with a Cognex Machine Vision System.  Furthermore you acknowledge
' and agree that Cognex has no warranty, obligations or liability for your use
' of the Software.
'*******************************************************************************
' This sample program is designed to illustrate certain VisionPro features or 
' techniques in the simplest way possible. It is not intended as the framework 
' for a complete application. In particular, the sample program may not provide
' proper error handling, event handling, cleanup, repeatability, and other 
' mechanisms that a commercial quality application requires.

' This sample program demonstrates the programmatic use of the VisionPro 2D Symbol
' Verify Tool.
'
' This program assumes that you have some knowledge of Visual Basic and VisionPro
' programming.
'
Option Explicit On
' needed for VisionPro
Imports Cognex.VisionPro
' needed for image processing
Imports Cognex.VisionPro.TwoDSymbol
Imports Cognex.VisionPro.Barcode
Imports Cognex.VisionPro.ImageFile
'needed for VisionPro exceptions
Imports Cognex.VisionPro.Display    'need to access CogDisplay
Imports Cognex.VisionPro.Exceptions
Imports Cognex.VisionPro.Implementation  ' need to access CogRecord

Imports System.IO.Path
Imports System.Drawing.Imaging

Public Class frmTwoDSymbolVerify
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIAQGLocationDeviationMin As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGLocationDeviationMean As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGLocationDeviationMax As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGSizeMean As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGSizeMax As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGOvalityMin As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGOvalityMean As System.Windows.Forms.TextBox
    Friend WithEvents txtIAQGOvalityMax As System.Windows.Forms.TextBox
    Friend WithEvents ctrDisplay As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSupplementalBackgroundUniformity As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplementalImageSharpness As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplementalModuleSeparability As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplementalFinderPatternConformity As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplementalSymbolSeparability As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAIMOverallGrade As System.Windows.Forms.TextBox
    Friend WithEvents txtAIMSymbolContrast As System.Windows.Forms.TextBox
    Friend WithEvents txtAIMUnusedErrorCorrection As System.Windows.Forms.TextBox
    Friend WithEvents txtAIMAxialNonuniformity As System.Windows.Forms.TextBox
    Friend WithEvents txtAIMPrintGrowthHorizontal As System.Windows.Forms.TextBox
    Friend WithEvents txtAIMPrintGrowthVertical As System.Windows.Forms.TextBox
    Friend WithEvents txtResultString As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkGrading As System.Windows.Forms.CheckBox
    Friend WithEvents btnLive As System.Windows.Forms.Button
    Friend WithEvents chkROICenter As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbROISize As System.Windows.Forms.TrackBar
    Friend WithEvents tbROIOriginY As System.Windows.Forms.TrackBar
    Friend WithEvents tbROIOriginX As System.Windows.Forms.TrackBar
    Friend WithEvents rbDataMatrix As System.Windows.Forms.RadioButton
    Friend WithEvents rbQRCode As System.Windows.Forms.RadioButton
    Friend WithEvents rbBarcode As System.Windows.Forms.RadioButton
    Friend WithEvents txtIAQGSizeMin As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTwoDSymbolVerify))
        Me.btnRun = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIAQGOvalityMax = New System.Windows.Forms.TextBox()
        Me.txtIAQGOvalityMean = New System.Windows.Forms.TextBox()
        Me.txtIAQGOvalityMin = New System.Windows.Forms.TextBox()
        Me.txtIAQGSizeMax = New System.Windows.Forms.TextBox()
        Me.txtIAQGSizeMean = New System.Windows.Forms.TextBox()
        Me.txtIAQGSizeMin = New System.Windows.Forms.TextBox()
        Me.txtIAQGLocationDeviationMax = New System.Windows.Forms.TextBox()
        Me.txtIAQGLocationDeviationMean = New System.Windows.Forms.TextBox()
        Me.txtIAQGLocationDeviationMin = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctrDisplay = New Cognex.VisionPro.Display.CogDisplay()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSupplementalSymbolSeparability = New System.Windows.Forms.TextBox()
        Me.txtSupplementalFinderPatternConformity = New System.Windows.Forms.TextBox()
        Me.txtSupplementalModuleSeparability = New System.Windows.Forms.TextBox()
        Me.txtSupplementalImageSharpness = New System.Windows.Forms.TextBox()
        Me.txtSupplementalBackgroundUniformity = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAIMPrintGrowthVertical = New System.Windows.Forms.TextBox()
        Me.txtAIMPrintGrowthHorizontal = New System.Windows.Forms.TextBox()
        Me.txtAIMAxialNonuniformity = New System.Windows.Forms.TextBox()
        Me.txtAIMUnusedErrorCorrection = New System.Windows.Forms.TextBox()
        Me.txtAIMSymbolContrast = New System.Windows.Forms.TextBox()
        Me.txtAIMOverallGrade = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtResultString = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkGrading = New System.Windows.Forms.CheckBox()
        Me.btnLive = New System.Windows.Forms.Button()
        Me.chkROICenter = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbROISize = New System.Windows.Forms.TrackBar()
        Me.tbROIOriginY = New System.Windows.Forms.TrackBar()
        Me.tbROIOriginX = New System.Windows.Forms.TrackBar()
        Me.rbDataMatrix = New System.Windows.Forms.RadioButton()
        Me.rbQRCode = New System.Windows.Forms.RadioButton()
        Me.rbBarcode = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ctrDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tbROISize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbROIOriginY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbROIOriginX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRun
        '
        Me.btnRun.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnRun.Location = New System.Drawing.Point(118, 12)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(100, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIAQGOvalityMax)
        Me.GroupBox1.Controls.Add(Me.txtIAQGOvalityMean)
        Me.GroupBox1.Controls.Add(Me.txtIAQGOvalityMin)
        Me.GroupBox1.Controls.Add(Me.txtIAQGSizeMax)
        Me.GroupBox1.Controls.Add(Me.txtIAQGSizeMean)
        Me.GroupBox1.Controls.Add(Me.txtIAQGSizeMin)
        Me.GroupBox1.Controls.Add(Me.txtIAQGLocationDeviationMax)
        Me.GroupBox1.Controls.Add(Me.txtIAQGLocationDeviationMean)
        Me.GroupBox1.Controls.Add(Me.txtIAQGLocationDeviationMin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(463, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 136)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IAQGDot Results"
        Me.GroupBox1.Visible = False
        '
        'txtIAQGOvalityMax
        '
        Me.txtIAQGOvalityMax.Location = New System.Drawing.Point(232, 104)
        Me.txtIAQGOvalityMax.Name = "txtIAQGOvalityMax"
        Me.txtIAQGOvalityMax.ReadOnly = True
        Me.txtIAQGOvalityMax.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGOvalityMax.TabIndex = 14
        '
        'txtIAQGOvalityMean
        '
        Me.txtIAQGOvalityMean.Location = New System.Drawing.Point(176, 104)
        Me.txtIAQGOvalityMean.Name = "txtIAQGOvalityMean"
        Me.txtIAQGOvalityMean.ReadOnly = True
        Me.txtIAQGOvalityMean.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGOvalityMean.TabIndex = 13
        '
        'txtIAQGOvalityMin
        '
        Me.txtIAQGOvalityMin.Location = New System.Drawing.Point(128, 104)
        Me.txtIAQGOvalityMin.Name = "txtIAQGOvalityMin"
        Me.txtIAQGOvalityMin.ReadOnly = True
        Me.txtIAQGOvalityMin.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGOvalityMin.TabIndex = 12
        '
        'txtIAQGSizeMax
        '
        Me.txtIAQGSizeMax.Location = New System.Drawing.Point(232, 64)
        Me.txtIAQGSizeMax.Name = "txtIAQGSizeMax"
        Me.txtIAQGSizeMax.ReadOnly = True
        Me.txtIAQGSizeMax.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGSizeMax.TabIndex = 11
        '
        'txtIAQGSizeMean
        '
        Me.txtIAQGSizeMean.Location = New System.Drawing.Point(176, 64)
        Me.txtIAQGSizeMean.Name = "txtIAQGSizeMean"
        Me.txtIAQGSizeMean.ReadOnly = True
        Me.txtIAQGSizeMean.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGSizeMean.TabIndex = 10
        '
        'txtIAQGSizeMin
        '
        Me.txtIAQGSizeMin.Location = New System.Drawing.Point(128, 62)
        Me.txtIAQGSizeMin.Name = "txtIAQGSizeMin"
        Me.txtIAQGSizeMin.ReadOnly = True
        Me.txtIAQGSizeMin.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGSizeMin.TabIndex = 9
        '
        'txtIAQGLocationDeviationMax
        '
        Me.txtIAQGLocationDeviationMax.Location = New System.Drawing.Point(232, 32)
        Me.txtIAQGLocationDeviationMax.Name = "txtIAQGLocationDeviationMax"
        Me.txtIAQGLocationDeviationMax.ReadOnly = True
        Me.txtIAQGLocationDeviationMax.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGLocationDeviationMax.TabIndex = 8
        '
        'txtIAQGLocationDeviationMean
        '
        Me.txtIAQGLocationDeviationMean.Location = New System.Drawing.Point(176, 32)
        Me.txtIAQGLocationDeviationMean.Name = "txtIAQGLocationDeviationMean"
        Me.txtIAQGLocationDeviationMean.ReadOnly = True
        Me.txtIAQGLocationDeviationMean.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGLocationDeviationMean.TabIndex = 7
        '
        'txtIAQGLocationDeviationMin
        '
        Me.txtIAQGLocationDeviationMin.Location = New System.Drawing.Point(128, 32)
        Me.txtIAQGLocationDeviationMin.Name = "txtIAQGLocationDeviationMin"
        Me.txtIAQGLocationDeviationMin.ReadOnly = True
        Me.txtIAQGLocationDeviationMin.Size = New System.Drawing.Size(40, 20)
        Me.txtIAQGLocationDeviationMin.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(232, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Max"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(176, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Mean"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(128, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Min"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ovality"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Size %"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Location Deviation %"
        '
        'ctrDisplay
        '
        Me.ctrDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.ctrDisplay.ColorMapLowerRoiLimit = 0.0R
        Me.ctrDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.ctrDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.ctrDisplay.ColorMapUpperRoiLimit = 1.0R
        Me.ctrDisplay.Location = New System.Drawing.Point(12, 143)
        Me.ctrDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.ctrDisplay.MouseWheelSensitivity = 1.0R
        Me.ctrDisplay.Name = "ctrDisplay"
        Me.ctrDisplay.OcxState = CType(resources.GetObject("ctrDisplay.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ctrDisplay.Size = New System.Drawing.Size(416, 347)
        Me.ctrDisplay.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSupplementalSymbolSeparability)
        Me.GroupBox2.Controls.Add(Me.txtSupplementalFinderPatternConformity)
        Me.GroupBox2.Controls.Add(Me.txtSupplementalModuleSeparability)
        Me.GroupBox2.Controls.Add(Me.txtSupplementalImageSharpness)
        Me.GroupBox2.Controls.Add(Me.txtSupplementalBackgroundUniformity)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(463, 338)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 168)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Supplemental Results"
        Me.GroupBox2.Visible = False
        '
        'txtSupplementalSymbolSeparability
        '
        Me.txtSupplementalSymbolSeparability.Location = New System.Drawing.Point(168, 136)
        Me.txtSupplementalSymbolSeparability.Name = "txtSupplementalSymbolSeparability"
        Me.txtSupplementalSymbolSeparability.ReadOnly = True
        Me.txtSupplementalSymbolSeparability.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplementalSymbolSeparability.TabIndex = 9
        '
        'txtSupplementalFinderPatternConformity
        '
        Me.txtSupplementalFinderPatternConformity.Location = New System.Drawing.Point(168, 104)
        Me.txtSupplementalFinderPatternConformity.Name = "txtSupplementalFinderPatternConformity"
        Me.txtSupplementalFinderPatternConformity.ReadOnly = True
        Me.txtSupplementalFinderPatternConformity.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplementalFinderPatternConformity.TabIndex = 8
        '
        'txtSupplementalModuleSeparability
        '
        Me.txtSupplementalModuleSeparability.Location = New System.Drawing.Point(168, 80)
        Me.txtSupplementalModuleSeparability.Name = "txtSupplementalModuleSeparability"
        Me.txtSupplementalModuleSeparability.ReadOnly = True
        Me.txtSupplementalModuleSeparability.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplementalModuleSeparability.TabIndex = 7
        '
        'txtSupplementalImageSharpness
        '
        Me.txtSupplementalImageSharpness.Location = New System.Drawing.Point(168, 56)
        Me.txtSupplementalImageSharpness.Name = "txtSupplementalImageSharpness"
        Me.txtSupplementalImageSharpness.ReadOnly = True
        Me.txtSupplementalImageSharpness.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplementalImageSharpness.TabIndex = 6
        '
        'txtSupplementalBackgroundUniformity
        '
        Me.txtSupplementalBackgroundUniformity.Location = New System.Drawing.Point(168, 32)
        Me.txtSupplementalBackgroundUniformity.Name = "txtSupplementalBackgroundUniformity"
        Me.txtSupplementalBackgroundUniformity.ReadOnly = True
        Me.txtSupplementalBackgroundUniformity.Size = New System.Drawing.Size(100, 20)
        Me.txtSupplementalBackgroundUniformity.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 23)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Symbol Separability"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 23)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Finder Pattern Conformity"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 23)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Module Separability"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 23)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Image Sharpness"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 23)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Background Uniformity"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAIMPrintGrowthVertical)
        Me.GroupBox3.Controls.Add(Me.txtAIMPrintGrowthHorizontal)
        Me.GroupBox3.Controls.Add(Me.txtAIMAxialNonuniformity)
        Me.GroupBox3.Controls.Add(Me.txtAIMUnusedErrorCorrection)
        Me.GroupBox3.Controls.Add(Me.txtAIMSymbolContrast)
        Me.GroupBox3.Controls.Add(Me.txtAIMOverallGrade)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(76, 525)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 144)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "AIM Results"
        Me.GroupBox3.Visible = False
        '
        'txtAIMPrintGrowthVertical
        '
        Me.txtAIMPrintGrowthVertical.Location = New System.Drawing.Point(216, 64)
        Me.txtAIMPrintGrowthVertical.Name = "txtAIMPrintGrowthVertical"
        Me.txtAIMPrintGrowthVertical.ReadOnly = True
        Me.txtAIMPrintGrowthVertical.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMPrintGrowthVertical.TabIndex = 14
        '
        'txtAIMPrintGrowthHorizontal
        '
        Me.txtAIMPrintGrowthHorizontal.Location = New System.Drawing.Point(136, 64)
        Me.txtAIMPrintGrowthHorizontal.Name = "txtAIMPrintGrowthHorizontal"
        Me.txtAIMPrintGrowthHorizontal.ReadOnly = True
        Me.txtAIMPrintGrowthHorizontal.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMPrintGrowthHorizontal.TabIndex = 13
        '
        'txtAIMAxialNonuniformity
        '
        Me.txtAIMAxialNonuniformity.Location = New System.Drawing.Point(216, 88)
        Me.txtAIMAxialNonuniformity.Name = "txtAIMAxialNonuniformity"
        Me.txtAIMAxialNonuniformity.ReadOnly = True
        Me.txtAIMAxialNonuniformity.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMAxialNonuniformity.TabIndex = 12
        '
        'txtAIMUnusedErrorCorrection
        '
        Me.txtAIMUnusedErrorCorrection.Location = New System.Drawing.Point(216, 112)
        Me.txtAIMUnusedErrorCorrection.Name = "txtAIMUnusedErrorCorrection"
        Me.txtAIMUnusedErrorCorrection.ReadOnly = True
        Me.txtAIMUnusedErrorCorrection.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMUnusedErrorCorrection.TabIndex = 11
        '
        'txtAIMSymbolContrast
        '
        Me.txtAIMSymbolContrast.Location = New System.Drawing.Point(216, 40)
        Me.txtAIMSymbolContrast.Name = "txtAIMSymbolContrast"
        Me.txtAIMSymbolContrast.ReadOnly = True
        Me.txtAIMSymbolContrast.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMSymbolContrast.TabIndex = 10
        '
        'txtAIMOverallGrade
        '
        Me.txtAIMOverallGrade.Location = New System.Drawing.Point(216, 16)
        Me.txtAIMOverallGrade.Name = "txtAIMOverallGrade"
        Me.txtAIMOverallGrade.ReadOnly = True
        Me.txtAIMOverallGrade.Size = New System.Drawing.Size(48, 20)
        Me.txtAIMOverallGrade.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 23)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Unused Error Correction"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 23)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Axial Nonuniformity"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 23)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Print Growth (H, V)"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 23)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Symbol Contrast"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Overall Grade"
        '
        'txtResultString
        '
        Me.txtResultString.BackColor = System.Drawing.SystemColors.Menu
        Me.txtResultString.Location = New System.Drawing.Point(110, 56)
        Me.txtResultString.Name = "txtResultString"
        Me.txtResultString.Size = New System.Drawing.Size(100, 20)
        Me.txtResultString.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(26, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Decode Result"
        '
        'chkGrading
        '
        Me.chkGrading.AutoSize = True
        Me.chkGrading.Location = New System.Drawing.Point(350, 10)
        Me.chkGrading.Name = "chkGrading"
        Me.chkGrading.Size = New System.Drawing.Size(63, 17)
        Me.chkGrading.TabIndex = 9
        Me.chkGrading.Text = "Grading"
        Me.chkGrading.UseVisualStyleBackColor = True
        '
        'btnLive
        '
        Me.btnLive.BackColor = System.Drawing.Color.SpringGreen
        Me.btnLive.Location = New System.Drawing.Point(12, 12)
        Me.btnLive.Name = "btnLive"
        Me.btnLive.Size = New System.Drawing.Size(100, 23)
        Me.btnLive.TabIndex = 10
        Me.btnLive.Text = "Live"
        Me.btnLive.UseVisualStyleBackColor = False
        '
        'chkROICenter
        '
        Me.chkROICenter.AutoSize = True
        Me.chkROICenter.Location = New System.Drawing.Point(350, 30)
        Me.chkROICenter.Name = "chkROICenter"
        Me.chkROICenter.Size = New System.Drawing.Size(45, 17)
        Me.chkROICenter.TabIndex = 13
        Me.chkROICenter.Text = "ROI"
        Me.chkROICenter.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(274, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Size:"
        '
        'tbROISize
        '
        Me.tbROISize.Location = New System.Drawing.Point(310, 62)
        Me.tbROISize.Maximum = 1000
        Me.tbROISize.Minimum = 10
        Me.tbROISize.Name = "tbROISize"
        Me.tbROISize.Size = New System.Drawing.Size(104, 45)
        Me.tbROISize.TabIndex = 16
        Me.tbROISize.Value = 500
        '
        'tbROIOriginY
        '
        Me.tbROIOriginY.BackColor = System.Drawing.Color.Lavender
        Me.tbROIOriginY.Location = New System.Drawing.Point(412, 143)
        Me.tbROIOriginY.Maximum = 1024
        Me.tbROIOriginY.Name = "tbROIOriginY"
        Me.tbROIOriginY.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbROIOriginY.Size = New System.Drawing.Size(45, 335)
        Me.tbROIOriginY.TabIndex = 17
        Me.tbROIOriginY.Value = 512
        '
        'tbROIOriginX
        '
        Me.tbROIOriginX.BackColor = System.Drawing.Color.Lavender
        Me.tbROIOriginX.Location = New System.Drawing.Point(12, 96)
        Me.tbROIOriginX.Maximum = 1280
        Me.tbROIOriginX.Name = "tbROIOriginX"
        Me.tbROIOriginX.Size = New System.Drawing.Size(400, 45)
        Me.tbROIOriginX.TabIndex = 18
        Me.tbROIOriginX.Value = 640
        '
        'rbDataMatrix
        '
        Me.rbDataMatrix.AutoSize = True
        Me.rbDataMatrix.Checked = True
        Me.rbDataMatrix.Location = New System.Drawing.Point(264, 6)
        Me.rbDataMatrix.Name = "rbDataMatrix"
        Me.rbDataMatrix.Size = New System.Drawing.Size(76, 17)
        Me.rbDataMatrix.TabIndex = 20
        Me.rbDataMatrix.TabStop = True
        Me.rbDataMatrix.Text = "DataMatrix"
        Me.rbDataMatrix.UseVisualStyleBackColor = True
        '
        'rbQRCode
        '
        Me.rbQRCode.AutoSize = True
        Me.rbQRCode.Location = New System.Drawing.Point(264, 24)
        Me.rbQRCode.Name = "rbQRCode"
        Me.rbQRCode.Size = New System.Drawing.Size(69, 17)
        Me.rbQRCode.TabIndex = 21
        Me.rbQRCode.TabStop = True
        Me.rbQRCode.Text = "QR Code"
        Me.rbQRCode.UseVisualStyleBackColor = True
        '
        'rbBarcode
        '
        Me.rbBarcode.AutoSize = True
        Me.rbBarcode.Location = New System.Drawing.Point(264, 42)
        Me.rbBarcode.Name = "rbBarcode"
        Me.rbBarcode.Size = New System.Drawing.Size(65, 17)
        Me.rbBarcode.TabIndex = 22
        Me.rbBarcode.Text = "Barcode"
        Me.rbBarcode.UseVisualStyleBackColor = True
        '
        'frmTwoDSymbolVerify
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(475, 530)
        Me.Controls.Add(Me.rbBarcode)
        Me.Controls.Add(Me.rbQRCode)
        Me.Controls.Add(Me.rbDataMatrix)
        Me.Controls.Add(Me.tbROIOriginX)
        Me.Controls.Add(Me.tbROIOriginY)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkROICenter)
        Me.Controls.Add(Me.btnLive)
        Me.Controls.Add(Me.chkGrading)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtResultString)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.ctrDisplay)
        Me.Controls.Add(Me.tbROISize)
        Me.Name = "frmTwoDSymbolVerify"
        Me.Text = "2D Symbol Decoder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ctrDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tbROISize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbROIOriginY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbROIOriginX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Module Level vars"

    Dim WithEvents camera As New uEye.Camera()
    Dim DisplayHandle As IntPtr
    Dim bLive As Boolean
    Dim ROISize, ROIOriginX, ROIOriginY As Double

    Const strFileName As String = "/Images/test2.bmp"
    Const strCovertedFileName As String = "/Images/test2.tif"
    Dim strBaseDir As String

    Private Rect As CogRectangle
    Private mVerifyTool As Cog2DSymbolVerifyTool
    Private m2DSymbolTool As Cog2DSymbolTool
    Private mBarcodeTool As CogBarcodeTool
    Private mImageFileTool As CogImageFileTool
    Private mobjLocStats As CogStatistics
    Private mobjSizeStats As CogStatistics
    Private mobjShapeStats As CogStatistics
    Private Const strNumericFormat As String = "##0.00"

    ' Note: The following global boolean, when set to False, means
    ' that only the first image in the database will be trained. Its
    ' characteristics will then be used to read and verify all subsequent
    ' images in the database. If set to True, it will train up a fresh
    ' pattern for each and every image in the database.
    Private Const blnTrainEveryImage As Boolean = False
#End Region
#Region " Form and Controls events"
    Private Sub frmTwoDSymbolVerify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strBaseDir = Environ("VPRO_ROOT")
        Me.Location = New Point(450, 0)
        rbDataMatrix.Checked = True
        frmCameraView.Show()
    End Sub

    Protected Friend Sub DisplaySearchRegion(x As Double, y As Double, width As Double, height As Double)
        Rect = New CogRectangle
        Rect.SetXYWidthHeight(x, y, width, height)
        ctrDisplay.InteractiveGraphics.Clear()
        ctrDisplay.InteractiveGraphics.Add(Rect, "main", True)
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        frmCameraView.CaptureImage()
        ConvertBMP(strBaseDir & strFileName, ImageFormat.Tiff)

        AnalyseImage()

    End Sub

    Private Sub chkGrading_CheckedChanged(sender As Object, e As EventArgs) Handles chkGrading.CheckedChanged
        If chkGrading.Checked = True Then
            GroupBox1.Visible = True
            GroupBox2.Visible = True
            GroupBox3.Visible = True
        Else
            GroupBox1.Visible = False
            GroupBox2.Visible = False
            GroupBox3.Visible = False

        End If
    End Sub

    Private Sub btnLive_Click(sender As Object, e As EventArgs) Handles btnLive.Click

        frmCameraView.Show()

    End Sub

    Private Sub tbROISize_Scroll(sender As Object, e As EventArgs) Handles tbROISize.Scroll
        ChangeROIScroll()
    End Sub

    Private Sub tbROIOriginX_Scroll(sender As Object, e As EventArgs) Handles tbROIOriginX.Scroll
        ChangeROIScroll()
    End Sub

    Private Sub tbROIOriginY_Scroll(sender As Object, e As EventArgs) Handles tbROIOriginY.Scroll
        ChangeROIScroll()
    End Sub

    Private Sub ChangeROIScroll()
        chkROICenter.Checked = True
        ROISize = tbROISize.Value
        ROIOriginX = tbROIOriginX.Value
        ROIOriginY = tbROIOriginY.Value
        If chkROICenter.Checked = True Then
            DisplaySearchRegion(ROIOriginX, 1024 - ROIOriginY, ROISize, ROISize)
        End If
    End Sub

    Private Sub CheckTextResult()
        If txtResultString.Text <> "" Then
            txtResultString.BackColor = Color.LightGreen
        ElseIf txtResultString.Text = "" Then
            txtResultString.BackColor = Color.Red
        End If
    End Sub

    Public Function ConvertBMP(ByVal BMPFullPath As String, _
ByVal imgFormat As ImageFormat) As Boolean

        Dim bAns As Boolean
        Dim sNewFile As String

        Try
            'bitmap class in system.drawing.imaging
            Dim objBmp As New Bitmap(BMPFullPath)

            'below 2 functions in system.io.path
            sNewFile = GetDirectoryName(BMPFullPath)
            sNewFile &= GetFileNameWithoutExtension(BMPFullPath)

            sNewFile &= "." & imgFormat.ToString
            objBmp.Save(sNewFile, imgFormat)

            bAns = True 'return true on success
        Catch
            bAns = False 'return false on error
        End Try
        Return bAns
        'USAGE
        'ConvertBMP("C:\test.bmp", ImageFormat.Jpeg)
        'ConvertBMP("C:\test.bmp", ImageFormat.Emf)
        'ConvertBMP("C:\test.bmp", ImageFormat.Exif)
        'ConvertBMP("C:\test.bmp", ImageFormat.Gif)
        'ConvertBMP("C:\test.bmp", ImageFormat.Icon)
        'ConvertBMP("C:\test.bmp", ImageFormat.MemoryBmp)
        'ConvertBMP("C:\test.bmp", ImageFormat.Png)
        'ConvertBMP("C:\test.bmp", ImageFormat.Tiff)
        'ConvertBMP("C:\test.bmp", ImageFormat.Wmf)
    End Function


#End Region

#Region "Analyse Image"
    Private Sub AnalyseImage()

        strBaseDir = Environ("VPRO_ROOT")

        ' Define tools
        Try
            mImageFileTool = New CogImageFileTool
            mVerifyTool = New Cog2DSymbolVerifyTool
            m2DSymbolTool = New Cog2DSymbolTool
            mBarcodeTool = New CogBarcodeTool

            mobjLocStats = New CogStatistics
            mobjSizeStats = New CogStatistics
            mobjShapeStats = New CogStatistics

            ' Set run parameters

            mVerifyTool.RunParams.MetricsAIMEnabled = True
            mVerifyTool.RunParams.MetricsSupplementalEnabled = True
            mVerifyTool.RunParams.MetricsIAQGDotEnabled = True
            mVerifyTool.RunParams.MetricsIAQGDotIncludeShapeInGrades = False

        Catch ex As Exception
            DisplayErrorAndExit("Encountered the following error: " & ex.Message)
        End Try

        ' Open images

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            ' clear result fields

            ResultAllClear()

            ' Get VPRO_ROOT from environment

            If strBaseDir = "" Then DisplayErrorAndExit("Required environment variable VPRO_ROOT not set.")

            ' Open file

            mImageFileTool.[Operator].Open(strBaseDir & strCovertedFileName, CogImageFileModeConstants.Read)

            ' Grab the next image
            mImageFileTool.Run()
            ' Update display
            ctrDisplay.Image = mImageFileTool.OutputImage
            ctrDisplay.InteractiveGraphics.Clear() ' Erase previous graphics
            ctrDisplay.Fit(True)

        Catch cogex As CogException
            MessageBox.Show("Following Specific Cognex Error Occured:" & cogex.Message)
        Catch ex As Exception
            DisplayErrorAndExit("Encountered the following error: " & Err.Description)

        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try
        ' end of open image

        'execute the 2d code or barcoed decoder method
        If rbDataMatrix.Checked Or rbQRCode.Checked Then

            ' Train reader. We'll use reader train results
            ' to set the majority of the verifier runtime params.
            Try

                If rbDataMatrix.Checked = True Then
                    m2DSymbolTool.Pattern.Symbology = Cog2DSymbolSymbologyConstants.DataMatrix
                ElseIf rbQRCode.Checked = True Then
                    m2DSymbolTool.Pattern.Symbology = Cog2DSymbolSymbologyConstants.QRCode
                End If

                If (blnTrainEveryImage Or (Not m2DSymbolTool.Pattern.Trained)) Then

                    m2DSymbolTool.Pattern.Untrain()
                    m2DSymbolTool.Pattern.TrainImage = mImageFileTool.OutputImage
                    m2DSymbolTool.Pattern.Train()
                End If
            Catch cogex As CogException
                MessageBox.Show("Following Specific Cognex Error Occured:" & cogex.Message)
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Cursors.Default
                DisplayErrorAndExit("Could not train reader to extract symbol characteristics!")
            End Try
            Try
                If Not m2DSymbolTool.Pattern.Trained Then

                End If
            Catch cogex As CogException
                MessageBox.Show("Following Specific Cognex Error Occured:" & cogex.Message)
            Catch ex As Exception
                DisplayErrorAndExit("Encountered the following error: " & Err.Description)

            Finally
                Windows.Forms.Cursor.Current = Cursors.Default
            End Try
            ' Execute reader. We'll use the reader results' grid to tell the verifier
            ' the bounds of the symbol in this image.
            Try
                ROISize = tbROISize.Value
                m2DSymbolTool.InputImage = mImageFileTool.OutputImage
                If chkROICenter.Checked = True Then
                    DisplaySearchRegion(ROIOriginX, 1024 - ROIOriginY, ROISize, ROISize)
                    m2DSymbolTool.SearchRegion = Rect

                Else
                    m2DSymbolTool.SearchRegion = Nothing ' search entire region
                End If
                m2DSymbolTool.Run()
                CheckTextResult()
                txtResultString.Text = m2DSymbolTool.Result.DecodedString.ToString()
                CheckTextResult()

            Catch cogex As CogException
                Windows.Forms.Cursor.Current = Cursors.Default
                'DisplayErrorAndExit("Could not run reader to determine symbol location!")
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Cursors.Default
                'DisplayErrorAndExit("Could not run reader to determine symbol location!")
            End Try

            ' Execute verifier.
            Try
                mVerifyTool.RunParams.Pattern = m2DSymbolTool.Pattern.TrainResult
                mVerifyTool.InputImage = mImageFileTool.OutputImage
                mVerifyTool.Region = m2DSymbolTool.Result.ResultGrid      ' Set CogRectangleAffine
                mVerifyTool.Run()

                ' Analyze and display verifyer results.
                ResultIAQGDotShow(mVerifyTool.Result.MetricsIAQGDot)
                ResultSupplementalShow(mVerifyTool.Result.MetricsSupplemental)
                ResultAIMShow(mVerifyTool.Result.MetricsAIM)
            Catch cogex As CogException
                Windows.Forms.Cursor.Current = Cursors.Default
                'DisplayErrorAndExit("Could not run verifyer to determine symbol quality!")
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Cursors.Default
                'DisplayErrorAndExit("Could not run verifyer to determine symbol quality!")
            End Try
            AddGraphicsContent(ctrDisplay, m2DSymbolTool.CreateLastRunRecord)

            Windows.Forms.Cursor.Current = Cursors.Default

        ElseIf rbBarcode.Checked Then
            Try
                ROISize = tbROISize.Value
                mBarcodeTool.InputImage = mImageFileTool.OutputImage
                If chkROICenter.Checked = True Then
                    DisplaySearchRegion(ROIOriginX, 1024 - ROIOriginY, ROISize, ROISize)
                    mBarcodeTool.Region = Rect

                Else
                    mBarcodeTool.Region = Nothing ' search entire region
                End If
                mBarcodeTool.InputImage = mImageFileTool.OutputImage
                CheckTextResult()
                mBarcodeTool.Run()
                Dim objRS As CogBarcodeResults
                Dim objR As CogBarcodeResult
                objRS = mBarcodeTool.Results
                Dim sTxt As String
                Dim iR As Integer
                For iR = 0 To objRS.Count - 1
                    objR = objRS.Item(iR)
                    If objR.OwnedDecoded IsNot Nothing Then
                        sTxt = objR.OwnedDecoded.String
                        txtResultString.Text = sTxt

                    End If
                    CheckTextResult()
                    AddGraphicsContent(ctrDisplay, mBarcodeTool.CreateLastRunRecord)
                Next iR

            Catch cogex As CogException
                MessageBox.Show("Following Specific Cognex Error Occured:" & cogex.Message)
            Catch ex As Exception
                Windows.Forms.Cursor.Current = Cursors.Default
                DisplayErrorAndExit("Could not train reader to extract symbol characteristics!")
            Finally
                Windows.Forms.Cursor.Current = Cursors.Default
            End Try

        End If


    End Sub
#End Region

#Region " Module Level Routines"
    ' Displays an error message and then exits the program.
    ' Call this when an unrecoverable error has occurred.
    Private Sub DisplayErrorAndExit(ByVal ErrorMsg As String)
        MessageBox.Show(ErrorMsg & Environment.NewLine)
        ' Me.Close() 'dont quite
        End      ' quit if it is called from Form_Load
    End Sub

    Private Function TextFromGrade(ByVal Grade As Cog2DSymbolVerifyGradeConstants) As String
        Dim strText As String
        strText = ""
        If Grade = Cog2DSymbolVerifyGradeConstants.A Then
            strText = "A"
        ElseIf Grade = Cog2DSymbolVerifyGradeConstants.B Then
            strText = "B"
        ElseIf Grade = Cog2DSymbolVerifyGradeConstants.C Then
            strText = "C"
        ElseIf Grade = Cog2DSymbolVerifyGradeConstants.D Then
            strText = "D"
        ElseIf Grade = Cog2DSymbolVerifyGradeConstants.F Then
            strText = "F"
        End If

        TextFromGrade = strText
    End Function

    Private Sub ResultAllClear()
        txtIAQGLocationDeviationMin.Text = ""
        txtIAQGLocationDeviationMean.Text = ""
        txtIAQGLocationDeviationMax.Text = ""
        txtIAQGSizeMin.Text = ""
        txtIAQGSizeMean.Text = ""
        txtIAQGSizeMax.Text = ""
        txtIAQGOvalityMin.Text = ""
        txtIAQGOvalityMean.Text = ""
        txtIAQGOvalityMax.Text = ""

        txtSupplementalBackgroundUniformity.Text = ""
        txtSupplementalImageSharpness.Text = ""
        txtSupplementalModuleSeparability.Text = ""
        txtSupplementalFinderPatternConformity.Text = ""
        txtSupplementalSymbolSeparability.Text = ""

        txtAIMOverallGrade.Text = ""
        txtAIMSymbolContrast.Text = ""
        txtAIMPrintGrowthHorizontal.Text = ""
        txtAIMPrintGrowthVertical.Text = ""
        txtAIMAxialNonuniformity.Text = ""
        txtAIMUnusedErrorCorrection.Text = ""

        txtResultString.Text = ""

        ctrDisplay.StaticGraphics.Clear()
        Refresh()

    End Sub

    Private Sub ResultIAQGDotShow(ByRef objIAQGDot As Cog2DSymbolVerifyIAQGDotResult)

        mobjLocStats.ResetRunningStatistics()
        mobjSizeStats.ResetRunningStatistics()
        mobjShapeStats.ResetRunningStatistics()

        If objIAQGDot Is Nothing Then Exit Sub ' No results then return

        Dim iRow As Integer, iCol As Integer
        Dim iLastRow As Integer, iLastCol As Integer
        iLastRow = objIAQGDot.NumRows - 1
        iLastCol = objIAQGDot.NumColumns - 1

        ' Loop through all rows and all columns. Wherever a dot is expected and found,
        ' fetch the results and update the statistics.
        For iRow = 0 To iLastRow
            For iCol = 0 To iLastCol
                If objIAQGDot.GetDotExpected(iCol, iRow) Then
                    If objIAQGDot.GetDotFound(iCol, iRow) Then
                        If objIAQGDot.GetLocationValid(iCol, iRow) Then
                            mobjLocStats.AddValue( _
                              objIAQGDot.GetLocationDeviationPercent(iCol, iRow))
                        End If
                        If objIAQGDot.GetSizeValid(iCol, iRow) Then
                            mobjSizeStats.AddValue( _
                              objIAQGDot.GetSizePercent(iCol, iRow))
                        End If
                        If objIAQGDot.GetShapeValid(iCol, iRow) Then
                            mobjShapeStats.AddValue( _
                              objIAQGDot.GetShapeOvality(iCol, iRow))
                        End If
                    End If
                End If
            Next iCol
        Next iRow

        ' Update the location result fields.
        If mobjLocStats.RunningNumSamples > 0 Then
            txtIAQGLocationDeviationMin.Text = _
              Format(mobjLocStats.RunningMinValue, strNumericFormat)
            txtIAQGLocationDeviationMean.Text = _
              Format(mobjLocStats.RunningMean, strNumericFormat)
            txtIAQGLocationDeviationMax.Text = _
              Format(mobjLocStats.RunningMaxValue, strNumericFormat)
        Else
            txtIAQGLocationDeviationMin.Text = ""
            txtIAQGLocationDeviationMean.Text = ""
            txtIAQGLocationDeviationMax.Text = ""
        End If
        ' Update the size result fields.
        If mobjSizeStats.RunningNumSamples > 0 Then
            txtIAQGSizeMin.Text = _
              Format(mobjSizeStats.RunningMinValue, strNumericFormat)
            txtIAQGSizeMean.Text = _
               Format(mobjSizeStats.RunningMean, strNumericFormat)
            txtIAQGSizeMax.Text = _
              Format(mobjSizeStats.RunningMaxValue, strNumericFormat)
        Else
            txtIAQGSizeMin.Text = ""
            txtIAQGSizeMean.Text = ""
            txtIAQGSizeMax.Text = ""
        End If
        ' Update the shape result fields.
        If mobjShapeStats.RunningNumSamples > 0 Then
            txtIAQGOvalityMin.Text = _
              Format(mobjShapeStats.RunningMinValue, strNumericFormat)
            txtIAQGOvalityMean.Text = _
              Format(mobjShapeStats.RunningMean, strNumericFormat)
            txtIAQGOvalityMax.Text = _
              Format(mobjShapeStats.RunningMaxValue, strNumericFormat)
        Else
            txtIAQGOvalityMin.Text = ""
            txtIAQGOvalityMean.Text = ""
            txtIAQGOvalityMax.Text = ""
        End If

        ' Generate a mask graphic for combined, and add it to the display. This will
        ' map color-coded translucent circles to the combined dot grade per
        ' expected dot.

        'Dim objLocMap As CogMaskGraphic
        'objLocMap = objIAQGDot.CreateResultMaskGraphic(Cog2DSymbolVerifyIAQGDotGraphicConstants.SizeMap)
        'ctrDisplay.StaticGraphics.Add(objLocMap, "test")
        'Show()
    End Sub

    Private Sub ResultSupplementalShow( _
      ByRef objSupplemental As Cog2DSymbolVerifySupplementalResult)

        If objSupplemental Is Nothing Then Exit Sub

        txtSupplementalBackgroundUniformity.Text = _
          Format(objSupplemental.BackgroundUniformity, strNumericFormat)
        txtSupplementalImageSharpness.Text = _
          Format(objSupplemental.ImageSharpness, strNumericFormat)
        txtSupplementalModuleSeparability.Text = _
          Format(objSupplemental.ModuleSeparability, strNumericFormat)
        txtSupplementalFinderPatternConformity.Text = _
          Format(objSupplemental.FinderPatternConformityDotmatrix, _
          strNumericFormat)
        txtSupplementalSymbolSeparability.Text = _
           Format(objSupplemental.SymbolSeparability, strNumericFormat)

    End Sub


    Private Sub ResultAIMShow(ByRef objAIM As Cog2DSymbolVerifyAIMResult)

        If objAIM Is Nothing Then
            txtAIMOverallGrade.Text = "F"
            Exit Sub
        End If

        txtAIMOverallGrade.Text = _
           TextFromGrade(objAIM.OverallSymbolGrade)
        txtAIMSymbolContrast.Text = _
          Format(objAIM.SymbolContrast, strNumericFormat)
        txtAIMPrintGrowthHorizontal.Text = _
          Format(objAIM.PrintGrowthHorizontal, strNumericFormat)
        txtAIMPrintGrowthVertical.Text = _
           Format(objAIM.PrintGrowthVertical, strNumericFormat)
        txtAIMAxialNonuniformity.Text = _
          Format(objAIM.AxialNonuniformity, strNumericFormat)

        If objAIM.ReferenceDecodeGrade = Cog2DSymbolVerifyGradeConstants.A Then
            txtAIMUnusedErrorCorrection.Text = _
              objAIM.UnusedErrorCorrection
        Else
            txtAIMUnusedErrorCorrection.Text = ""
        End If

    End Sub

    Private Sub AddGraphicsContent(ByVal display As CogDisplay, ByVal parent As ICogRecord)
        ' Step through the records.
        Dim record As CogRecord
        For Each record In parent.SubRecords
            ' A single graphic.
            If GetType(ICogGraphic).IsAssignableFrom((record.ContentType)) Then

                If Not record.Content Is Nothing Then
                    display.InteractiveGraphics.Add(record.Content, "IDResult", False)
                End If
                ' A list of graphics.
            ElseIf (GetType(CogGraphicCollection).IsAssignableFrom(record.ContentType)) Then

                If Not record.Content Is Nothing Then
                    Dim graphics As CogGraphicCollection
                    graphics = record.Content
                    Dim graphic As ICogGraphic
                    For Each graphic In graphics
                        Dim graphici As ICogGraphicInteractive
                        graphici = graphic
                        display.InteractiveGraphics.Add(graphici, "Result", False)
                    Next
                End If

            ElseIf (GetType(CogGraphicInteractiveCollection).IsAssignableFrom(record.ContentType)) Then

                If Not record.Content Is Nothing Then

                    display.InteractiveGraphics.AddList(record.Content, "IDResult", False)
                End If
            End If
            ' Add the sub-records, if any.
            AddGraphicsContent(display, record)

        Next
    End Sub
#End Region


End Class
