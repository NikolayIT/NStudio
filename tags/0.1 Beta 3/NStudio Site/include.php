<?
require_once("info.php");
// 
function head()
{
	global $name, $version, $bgcolor;
	echo("<table width='100%'>");
	echo("<tr>");
	echo("<td align=center bgcolor='$bgcolor'>");
	//echo("<font color=red size=6><b>$name $version</b></font>");
	echo("<img src='header.jpg' alt='$name $version' border=0>");
	echo("</td>");
	echo("</tr>");
	echo("<tr>");
	echo("<td>");
	menu();
	echo("</td>");
	echo("</tr>");
	echo("<tr>");
	echo("<td>");
}
function startpage()
{
	global $name, $version;
	echo("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">\n");
	echo("<html>");
	echo("<head>");
	echo("<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">");
	echo("<title>$name $version</title>");
	echo("</head>");
	echo("<body BGCOLOR='#000000' TEXT='#FFFFFF' LINK='yellow' VLINK='yellow'>");
	head();
}
function menu()
{
	global $forum, $menubgcolor;
	echo("<table border=1 width='100%'>");
	echo("<tr>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='index.php'>Home</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='download.php'>Download</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='features.php'>Features</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='screens.php'>Screenshots</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='history.php'>History</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='plugins.php'>Plugins</a>");
	echo("</td>");
	echo("<td bgcolor='$menubgcolor'>");
	echo("<a href='$forum'>Forum</a>");
	echo("</td>");
	echo("</tr>");
	echo("</table>");
}
function footer()
{
	global $bgcolor;
	echo("</td>");
	echo("</tr>");
	echo("<tr>");
	echo("<td align='center' bgcolor='$bgcolor'>");
	echo("Latest change: 16 September 2007<br>");
	echo("Copyright 2007 NRPG. All rights reserved.<br>");
	?><script  type="text/javascript">
d=document;
d.write('<a href="http://www.tyxo.bg/?19764" title="Tyxo.bg counter" target=" blank"><img width="88" height="31" border="0" alt="Tyxo.bg counter"');
d.write(' src="http://cnt.tyxo.bg/19764?rnd='+Math.round(Math.random()*2147483647));
d.write('&sp='+screen.width+'x'+screen.height+'&r='+escape(d.referrer)+'" /><\/a>');
//-->
</script>
<noscript><a href="http://www.tyxo.bg/?19764" title="Tyxo.bg counter" target=" blank"><img src="http://cnt.tyxo.bg/19764" width="88" height="31" border="0" alt="Tyxo.bg counter" /></a></noscript>
<a href="http://validator.w3.org/check?uri=referer">
<img src="http://www.w3.org/Icons/valid-html401" alt="Valid HTML 4.01 Transitional" height="31" width="88" border=0>
</a>
<?
	echo("</td>");
	echo("</tr>");
	echo("</table>");
}
function endpage()
{
	footer();
	echo("</body>");
	echo("</html>");
}
?>
