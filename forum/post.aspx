<%@ Page Language="c#" Codebehind="post.aspx.cs" Inherits="RSDNMag.Forum.SendPost" EnableViewState="False" codePage="1251" EnableSessionState="ReadOnly" validateRequest="False" AutoEventWireup="false" %>
<HTML>
	<HEAD>
		<title>Создание сообщения</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<META http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<style>.ETool { PADDING-RIGHT: 2px; PADDING-LEFT: 2px; FONT-WEIGHT: bold; PADDING-BOTTOM: 2px; COLOR: black; PADDING-TOP: 2px; BACKGROUND-COLOR: white }
	.EToolHover { PADDING-RIGHT: 2px; PADDING-LEFT: 2px; FONT-WEIGHT: bold; PADDING-BOTTOM: 2px; CURSOR: hand; COLOR: blue; PADDING-TOP: 2px; BACKGROUND-COLOR: #a7c6ff }
	.MBox { WIDTH: 408px; HEIGHT: 184px }
	.SBox { WIDTH: 200px }
	.Button { FONT-SIZE: 8pt; Z-INDEX: 115; LEFT: 96px; WIDTH: 72px; FONT-FAMILY: Verdana,Arial; POSITION: absolute; TOP: 320px; HEIGHT: 24px }
		</style>
		<script src="options.js"></script>
	</HEAD>
	<body ms_positioning="GridLayout">
		<form runat="server">
			<asp:textbox id="AuthorName" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 48px"
				runat="server" MaxLength="30" Width="200px" Font-Names="Verdana,Arial" Font-Size="8pt" CssClass="SBox"></asp:textbox><asp:label id="Label1" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 32px" runat="server"
				font-bold="True" font-size="8pt" font-names="Verdana,Arial">Имя:</asp:label><asp:label id="Label2" style="Z-INDEX: 105; LEFT: 224px; POSITION: absolute; TOP: 32px" runat="server"
				font-bold="True" font-size="8pt" font-names="Verdana,Arial">Тема:</asp:label><asp:textbox id="Topic" style="Z-INDEX: 106; LEFT: 224px; POSITION: absolute; TOP: 48px" runat="server"
				MaxLength="30" Width="200px" Font-Names="Verdana,Arial" Font-Size="8pt" CssClass="SBox"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 80px" runat="server"
				font-bold="True" font-size="8pt" font-names="Verdana,Arial">Сообщение:</asp:label>
			<div id="Format" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; Z-INDEX: 102; LEFT: 16px; WIDTH: 406px; FONT-FAMILY: Verdana,Arial; POSITION: absolute; TOP: 288px; HEIGHT: 16px">Форматирование:&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="ETool" onmouseover="this.className='EToolHover';" onclick="pasteTag('[b]здесь[/b]');"
					onmouseout="this.className='ETool';">B</span> &nbsp;&nbsp; <span class="ETool" onmouseover="this.className='EToolHover';" onclick="pasteTag('[i]здесь[/i]');"
					onmouseout="this.className='ETool';">I</span> &nbsp;&nbsp; <span class="ETool" onmouseover="this.className='EToolHover';" onclick="pasteTag('[u]здесь[/u]');"
					onmouseout="this.className='ETool';">U</span>&nbsp;&nbsp;&nbsp;<SPAN class="ETool" onmouseover="this.className='EToolHover';" onclick="pasteTag('[url]здесь[/url]');"
					onmouseout="this.className='ETool';">URL</SPAN>&nbsp;
			</div>
			<DIV style="PADDING-RIGHT: 4px; DISPLAY: inline; PADDING-LEFT: 4px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; Z-INDEX: 108; LEFT: 0px; PADDING-BOTTOM: 2px; MARGIN: 0px; TEXT-TRANSFORM: uppercase; WIDTH: 438px; COLOR: white; PADDING-TOP: 4px; FONT-FAMILY: Verdana,Arial; POSITION: absolute; TOP: 0px; HEIGHT: 24px; BACKGROUND-COLOR: gray"
				ms_positioning="FlowLayout">Создание сообщения</DIV>
			<DIV style="PADDING-RIGHT: 4px; DISPLAY: inline; PADDING-LEFT: 4px; FONT-WEIGHT: bold; FONT-SIZE: 8pt; Z-INDEX: 109; LEFT: 0px; PADDING-BOTTOM: 2px; MARGIN: 0px; TEXT-TRANSFORM: uppercase; WIDTH: 438px; COLOR: white; PADDING-TOP: 4px; FONT-FAMILY: Verdana,Arial; POSITION: absolute; TOP: 354px; HEIGHT: 24px; BACKGROUND-COLOR: gray"
				ms_positioning="FlowLayout"></DIV>
			<asp:textbox id="Msg" style="Z-INDEX: 110; LEFT: 16px; POSITION: absolute; TOP: 96px" runat="server"
				MaxLength="2000" Width="408px" Height="184px" TextMode="MultiLine" Font-Names="Verdana,Arial"
				Font-Size="8pt" CssClass="MBox"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" style="Z-INDEX: 111; LEFT: 8px; POSITION: absolute; TOP: 392px"
				runat="server" ErrorMessage="поле для ввода имени" ControlToValidate="AuthorName" Display="None"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator2" style="Z-INDEX: 112; LEFT: 8px; POSITION: absolute; TOP: 416px"
				runat="server" ErrorMessage="поле для ввода темы" ControlToValidate="Topic" Display="None"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" style="Z-INDEX: 113; LEFT: 8px; POSITION: absolute; TOP: 440px"
				runat="server" ErrorMessage="поле для ввода текста сообщения" ControlToValidate="Msg" Display="None"></asp:requiredfieldvalidator><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 114; LEFT: 184px; POSITION: absolute; TOP: 304px"
				runat="server" Width="216px" Height="48px" Font-Names="Verdana,Arial" Font-Size="7pt" DisplayMode="List" HeaderText="Вы не заполнили:"></asp:validationsummary><INPUT class="Button" id="Cancel" style="Z-INDEX: 101" onclick="window.close();" type="button"
				value="Отмена">&nbsp;
			<asp:Button id="OK" style="Z-INDEX: 115; LEFT: 16px; POSITION: absolute; TOP: 320px" runat="server"
				Text="OK" CssClass="Button"></asp:Button>
			<!-- Insert content here --></form>
		<script>
		function pasteTag(tag)
		{
			document.getElementById("Msg").value += tag;
		}
		</script>
	</body>
</HTML>
