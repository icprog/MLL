using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using FastReport;
using FastReport.Data;
using FastReport.Dialog;
using FastReport.Barcode;
using FastReport.Table;
using FastReport.Utils;

namespace FastReport
{
  public class cpdar_404 : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.Table.TableCell Cell1;
    public FastReport.Table.TableCell Cell10;
    public FastReport.Table.TableCell Cell11;
    public FastReport.Table.TableCell Cell12;
    public FastReport.Table.TableCell Cell13;
    public FastReport.Table.TableCell Cell14;
    public FastReport.Table.TableCell Cell15;
    public FastReport.Table.TableCell Cell16;
    public FastReport.Table.TableCell Cell17;
    public FastReport.Table.TableCell Cell18;
    public FastReport.Table.TableCell Cell19;
    public FastReport.Table.TableCell Cell2;
    public FastReport.Table.TableCell Cell20;
    public FastReport.Table.TableCell Cell21;
    public FastReport.Table.TableCell Cell22;
    public FastReport.Table.TableCell Cell23;
    public FastReport.Table.TableCell Cell24;
    public FastReport.Table.TableCell Cell25;
    public FastReport.Table.TableCell Cell251;
    public FastReport.Table.TableCell Cell252;
    public FastReport.Table.TableCell Cell253;
    public FastReport.Table.TableCell Cell254;
    public FastReport.Table.TableCell Cell255;
    public FastReport.Table.TableCell Cell256;
    public FastReport.Table.TableCell Cell257;
    public FastReport.Table.TableCell Cell258;
    public FastReport.Table.TableCell Cell259;
    public FastReport.Table.TableCell Cell26;
    public FastReport.Table.TableCell Cell260;
    public FastReport.Table.TableCell Cell261;
    public FastReport.Table.TableCell Cell262;
    public FastReport.Table.TableCell Cell263;
    public FastReport.Table.TableCell Cell264;
    public FastReport.Table.TableCell Cell265;
    public FastReport.Table.TableCell Cell266;
    public FastReport.Table.TableCell Cell267;
    public FastReport.Table.TableCell Cell268;
    public FastReport.Table.TableCell Cell269;
    public FastReport.Table.TableCell Cell27;
    public FastReport.Table.TableCell Cell270;
    public FastReport.Table.TableCell Cell271;
    public FastReport.Table.TableCell Cell272;
    public FastReport.Table.TableCell Cell273;
    public FastReport.Table.TableCell Cell274;
    public FastReport.Table.TableCell Cell275;
    public FastReport.Table.TableCell Cell276;
    public FastReport.Table.TableCell Cell277;
    public FastReport.Table.TableCell Cell278;
    public FastReport.Table.TableCell Cell279;
    public FastReport.Table.TableCell Cell28;
    public FastReport.Table.TableCell Cell280;
    public FastReport.Table.TableCell Cell281;
    public FastReport.Table.TableCell Cell282;
    public FastReport.Table.TableCell Cell283;
    public FastReport.Table.TableCell Cell284;
    public FastReport.Table.TableCell Cell285;
    public FastReport.Table.TableCell Cell286;
    public FastReport.Table.TableCell Cell287;
    public FastReport.Table.TableCell Cell288;
    public FastReport.Table.TableCell Cell289;
    public FastReport.Table.TableCell Cell29;
    public FastReport.Table.TableCell Cell290;
    public FastReport.Table.TableCell Cell291;
    public FastReport.Table.TableCell Cell292;
    public FastReport.Table.TableCell Cell293;
    public FastReport.Table.TableCell Cell294;
    public FastReport.Table.TableCell Cell295;
    public FastReport.Table.TableCell Cell296;
    public FastReport.Table.TableCell Cell297;
    public FastReport.Table.TableCell Cell298;
    public FastReport.Table.TableCell Cell299;
    public FastReport.Table.TableCell Cell3;
    public FastReport.Table.TableCell Cell30;
    public FastReport.Table.TableCell Cell300;
    public FastReport.Table.TableCell Cell301;
    public FastReport.Table.TableCell Cell302;
    public FastReport.Table.TableCell Cell303;
    public FastReport.Table.TableCell Cell304;
    public FastReport.Table.TableCell Cell305;
    public FastReport.Table.TableCell Cell306;
    public FastReport.Table.TableCell Cell307;
    public FastReport.Table.TableCell Cell308;
    public FastReport.Table.TableCell Cell309;
    public FastReport.Table.TableCell Cell310;
    public FastReport.Table.TableCell Cell311;
    public FastReport.Table.TableCell Cell312;
    public FastReport.Table.TableCell Cell313;
    public FastReport.Table.TableCell Cell314;
    public FastReport.Table.TableCell Cell315;
    public FastReport.Table.TableCell Cell316;
    public FastReport.Table.TableCell Cell317;
    public FastReport.Table.TableCell Cell318;
    public FastReport.Table.TableCell Cell319;
    public FastReport.Table.TableCell Cell320;
    public FastReport.Table.TableCell Cell321;
    public FastReport.Table.TableCell Cell322;
    public FastReport.Table.TableCell Cell323;
    public FastReport.Table.TableCell Cell324;
    public FastReport.Table.TableCell Cell325;
    public FastReport.Table.TableCell Cell326;
    public FastReport.Table.TableCell Cell327;
    public FastReport.Table.TableCell Cell328;
    public FastReport.Table.TableCell Cell329;
    public FastReport.Table.TableCell Cell330;
    public FastReport.Table.TableCell Cell331;
    public FastReport.Table.TableCell Cell332;
    public FastReport.Table.TableCell Cell333;
    public FastReport.Table.TableCell Cell334;
    public FastReport.Table.TableCell Cell335;
    public FastReport.Table.TableCell Cell336;
    public FastReport.Table.TableCell Cell337;
    public FastReport.Table.TableCell Cell338;
    public FastReport.Table.TableCell Cell339;
    public FastReport.Table.TableCell Cell340;
    public FastReport.Table.TableCell Cell341;
    public FastReport.Table.TableCell Cell342;
    public FastReport.Table.TableCell Cell343;
    public FastReport.Table.TableCell Cell344;
    public FastReport.Table.TableCell Cell345;
    public FastReport.Table.TableCell Cell346;
    public FastReport.Table.TableCell Cell381;
    public FastReport.Table.TableCell Cell382;
    public FastReport.Table.TableCell Cell383;
    public FastReport.Table.TableCell Cell386;
    public FastReport.Table.TableCell Cell387;
    public FastReport.Table.TableCell Cell388;
    public FastReport.Table.TableCell Cell391;
    public FastReport.Table.TableCell Cell392;
    public FastReport.Table.TableCell Cell393;
    public FastReport.Table.TableCell Cell394;
    public FastReport.Table.TableCell Cell395;
    public FastReport.Table.TableCell Cell396;
    public FastReport.Table.TableCell Cell397;
    public FastReport.Table.TableCell Cell398;
    public FastReport.Table.TableCell Cell399;
    public FastReport.Table.TableCell Cell4;
    public FastReport.Table.TableCell Cell400;
    public FastReport.Table.TableCell Cell401;
    public FastReport.Table.TableCell Cell402;
    public FastReport.Table.TableCell Cell403;
    public FastReport.Table.TableCell Cell404;
    public FastReport.Table.TableCell Cell405;
    public FastReport.Table.TableCell Cell406;
    public FastReport.Table.TableCell Cell407;
    public FastReport.Table.TableCell Cell408;
    public FastReport.Table.TableCell Cell409;
    public FastReport.Table.TableCell Cell410;
    public FastReport.Table.TableCell Cell411;
    public FastReport.Table.TableCell Cell412;
    public FastReport.Table.TableCell Cell413;
    public FastReport.Table.TableCell Cell414;
    public FastReport.Table.TableCell Cell415;
    public FastReport.Table.TableCell Cell416;
    public FastReport.Table.TableCell Cell417;
    public FastReport.Table.TableCell Cell418;
    public FastReport.Table.TableCell Cell419;
    public FastReport.Table.TableCell Cell420;
    public FastReport.Table.TableCell Cell421;
    public FastReport.Table.TableCell Cell422;
    public FastReport.Table.TableCell Cell423;
    public FastReport.Table.TableCell Cell424;
    public FastReport.Table.TableCell Cell425;
    public FastReport.Table.TableCell Cell426;
    public FastReport.Table.TableCell Cell427;
    public FastReport.Table.TableCell Cell428;
    public FastReport.Table.TableCell Cell429;
    public FastReport.Table.TableCell Cell430;
    public FastReport.Table.TableCell Cell431;
    public FastReport.Table.TableCell Cell432;
    public FastReport.Table.TableCell Cell433;
    public FastReport.Table.TableCell Cell434;
    public FastReport.Table.TableCell Cell435;
    public FastReport.Table.TableCell Cell436;
    public FastReport.Table.TableCell Cell437;
    public FastReport.Table.TableCell Cell438;
    public FastReport.Table.TableCell Cell439;
    public FastReport.Table.TableCell Cell440;
    public FastReport.Table.TableCell Cell441;
    public FastReport.Table.TableCell Cell442;
    public FastReport.Table.TableCell Cell443;
    public FastReport.Table.TableCell Cell444;
    public FastReport.Table.TableCell Cell445;
    public FastReport.Table.TableCell Cell446;
    public FastReport.Table.TableCell Cell447;
    public FastReport.Table.TableCell Cell448;
    public FastReport.Table.TableCell Cell449;
    public FastReport.Table.TableCell Cell450;
    public FastReport.Table.TableCell Cell451;
    public FastReport.Table.TableCell Cell452;
    public FastReport.Table.TableCell Cell453;
    public FastReport.Table.TableCell Cell454;
    public FastReport.Table.TableCell Cell455;
    public FastReport.Table.TableCell Cell456;
    public FastReport.Table.TableCell Cell457;
    public FastReport.Table.TableCell Cell458;
    public FastReport.Table.TableCell Cell459;
    public FastReport.Table.TableCell Cell460;
    public FastReport.Table.TableCell Cell461;
    public FastReport.Table.TableCell Cell462;
    public FastReport.Table.TableCell Cell463;
    public FastReport.Table.TableCell Cell464;
    public FastReport.Table.TableCell Cell465;
    public FastReport.Table.TableCell Cell466;
    public FastReport.Table.TableCell Cell467;
    public FastReport.Table.TableCell Cell468;
    public FastReport.Table.TableCell Cell469;
    public FastReport.Table.TableCell Cell470;
    public FastReport.Table.TableCell Cell471;
    public FastReport.Table.TableCell Cell472;
    public FastReport.Table.TableCell Cell473;
    public FastReport.Table.TableCell Cell474;
    public FastReport.Table.TableCell Cell475;
    public FastReport.Table.TableCell Cell476;
    public FastReport.Table.TableCell Cell477;
    public FastReport.Table.TableCell Cell478;
    public FastReport.Table.TableCell Cell479;
    public FastReport.Table.TableCell Cell5;
    public FastReport.Table.TableCell Cell6;
    public FastReport.Table.TableCell Cell7;
    public FastReport.Table.TableCell Cell8;
    public FastReport.Table.TableCell Cell9;
    public FastReport.CheckBoxObject CheckBox1;
    public FastReport.CheckBoxObject CheckBox10;
    public FastReport.CheckBoxObject CheckBox11;
    public FastReport.CheckBoxObject CheckBox12;
    public FastReport.CheckBoxObject CheckBox13;
    public FastReport.CheckBoxObject CheckBox15;
    public FastReport.CheckBoxObject CheckBox17;
    public FastReport.CheckBoxObject CheckBox18;
    public FastReport.CheckBoxObject CheckBox19;
    public FastReport.CheckBoxObject CheckBox2;
    public FastReport.CheckBoxObject CheckBox20;
    public FastReport.CheckBoxObject CheckBox21;
    public FastReport.CheckBoxObject CheckBox22;
    public FastReport.CheckBoxObject CheckBox23;
    public FastReport.CheckBoxObject CheckBox27;
    public FastReport.CheckBoxObject CheckBox28;
    public FastReport.CheckBoxObject CheckBox29;
    public FastReport.CheckBoxObject CheckBox3;
    public FastReport.CheckBoxObject CheckBox34;
    public FastReport.CheckBoxObject CheckBox35;
    public FastReport.CheckBoxObject CheckBox36;
    public FastReport.CheckBoxObject CheckBox37;
    public FastReport.CheckBoxObject CheckBox38;
    public FastReport.CheckBoxObject CheckBox39;
    public FastReport.CheckBoxObject CheckBox4;
    public FastReport.CheckBoxObject CheckBox40;
    public FastReport.CheckBoxObject CheckBox41;
    public FastReport.CheckBoxObject CheckBox42;
    public FastReport.CheckBoxObject CheckBox43;
    public FastReport.CheckBoxObject CheckBox44;
    public FastReport.CheckBoxObject CheckBox45;
    public FastReport.CheckBoxObject CheckBox46;
    public FastReport.CheckBoxObject CheckBox47;
    public FastReport.CheckBoxObject CheckBox48;
    public FastReport.CheckBoxObject CheckBox49;
    public FastReport.CheckBoxObject CheckBox5;
    public FastReport.CheckBoxObject CheckBox50;
    public FastReport.CheckBoxObject CheckBox51;
    public FastReport.CheckBoxObject CheckBox52;
    public FastReport.CheckBoxObject CheckBox53;
    public FastReport.CheckBoxObject CheckBox54;
    public FastReport.CheckBoxObject CheckBox55;
    public FastReport.CheckBoxObject CheckBox56;
    public FastReport.CheckBoxObject CheckBox57;
    public FastReport.CheckBoxObject CheckBox58;
    public FastReport.CheckBoxObject CheckBox59;
    public FastReport.CheckBoxObject CheckBox6;
    public FastReport.CheckBoxObject CheckBox60;
    public FastReport.CheckBoxObject CheckBox61;
    public FastReport.CheckBoxObject CheckBox62;
    public FastReport.CheckBoxObject CheckBox63;
    public FastReport.CheckBoxObject CheckBox64;
    public FastReport.CheckBoxObject CheckBox65;
    public FastReport.CheckBoxObject CheckBox66;
    public FastReport.CheckBoxObject CheckBox67;
    public FastReport.CheckBoxObject CheckBox68;
    public FastReport.CheckBoxObject CheckBox69;
    public FastReport.CheckBoxObject CheckBox7;
    public FastReport.CheckBoxObject CheckBox70;
    public FastReport.CheckBoxObject CheckBox71;
    public FastReport.CheckBoxObject CheckBox72;
    public FastReport.CheckBoxObject CheckBox73;
    public FastReport.CheckBoxObject CheckBox74;
    public FastReport.CheckBoxObject CheckBox75;
    public FastReport.CheckBoxObject CheckBox76;
    public FastReport.CheckBoxObject CheckBox77;
    public FastReport.CheckBoxObject CheckBox8;
    public FastReport.CheckBoxObject CheckBox9;
    public FastReport.Table.TableColumn Column1;
    public FastReport.Table.TableColumn Column10;
    public FastReport.Table.TableColumn Column11;
    public FastReport.Table.TableColumn Column12;
    public FastReport.Table.TableColumn Column13;
    public FastReport.Table.TableColumn Column14;
    public FastReport.Table.TableColumn Column15;
    public FastReport.Table.TableColumn Column16;
    public FastReport.Table.TableColumn Column2;
    public FastReport.Table.TableColumn Column20;
    public FastReport.Table.TableColumn Column21;
    public FastReport.Table.TableColumn Column22;
    public FastReport.Table.TableColumn Column23;
    public FastReport.Table.TableColumn Column24;
    public FastReport.Table.TableColumn Column25;
    public FastReport.Table.TableColumn Column26;
    public FastReport.Table.TableColumn Column27;
    public FastReport.Table.TableColumn Column28;
    public FastReport.Table.TableColumn Column29;
    public FastReport.Table.TableColumn Column3;
    public FastReport.Table.TableColumn Column30;
    public FastReport.Table.TableColumn Column31;
    public FastReport.Table.TableColumn Column32;
    public FastReport.Table.TableColumn Column33;
    public FastReport.Table.TableColumn Column34;
    public FastReport.Table.TableColumn Column35;
    public FastReport.Table.TableColumn Column36;
    public FastReport.Table.TableColumn Column4;
    public FastReport.Table.TableColumn Column5;
    public FastReport.Table.TableColumn Column6;
    public FastReport.Table.TableColumn Column7;
    public FastReport.Table.TableColumn Column8;
    public FastReport.Table.TableColumn Column9;
    public FastReport.DataBand Data1;
    public FastReport.ReportPage Page1;
    public FastReport.PictureObject Picture1;
    public FastReport.PictureObject Picture2;
    public FastReport.PictureObject Picture3;
    public FastReport.PictureObject Picture4;
    public FastReport.PictureObject Picture5;
    public FastReport.PictureObject Picture6;
    public FastReport.PictureObject Picture7;
    public FastReport.PictureObject Picture8;
    public FastReport.ReportSummaryBand ReportSummary1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.Table.TableRow Row1;
    public FastReport.Table.TableRow Row10;
    public FastReport.Table.TableRow Row11;
    public FastReport.Table.TableRow Row12;
    public FastReport.Table.TableRow Row13;
    public FastReport.Table.TableRow Row14;
    public FastReport.Table.TableRow Row15;
    public FastReport.Table.TableRow Row16;
    public FastReport.Table.TableRow Row17;
    public FastReport.Table.TableRow Row18;
    public FastReport.Table.TableRow Row19;
    public FastReport.Table.TableRow Row2;
    public FastReport.Table.TableRow Row20;
    public FastReport.Table.TableRow Row21;
    public FastReport.Table.TableRow Row22;
    public FastReport.Table.TableRow Row23;
    public FastReport.Table.TableRow Row24;
    public FastReport.Table.TableRow Row3;
    public FastReport.Table.TableRow Row33;
    public FastReport.Table.TableRow Row34;
    public FastReport.Table.TableRow Row35;
    public FastReport.Table.TableRow Row36;
    public FastReport.Table.TableRow Row37;
    public FastReport.Table.TableRow Row38;
    public FastReport.Table.TableRow Row39;
    public FastReport.Table.TableRow Row4;
    public FastReport.Table.TableRow Row40;
    public FastReport.Table.TableRow Row41;
    public FastReport.Table.TableRow Row42;
    public FastReport.Table.TableRow Row43;
    public FastReport.Table.TableRow Row44;
    public FastReport.Table.TableRow Row45;
    public FastReport.Table.TableRow Row46;
    public FastReport.Table.TableRow Row47;
    public FastReport.Table.TableRow Row48;
    public FastReport.Table.TableRow Row49;
    public FastReport.Table.TableRow Row5;
    public FastReport.Table.TableRow Row50;
    public FastReport.Table.TableRow Row6;
    public FastReport.Table.TableRow Row7;
    public FastReport.Table.TableRow Row8;
    public FastReport.Table.TableRow Row9;
    public FastReport.Table.TableObject Table1;
    public FastReport.Table.TableObject Table2;
    public FastReport.Table.TableObject Table3;
    public FastReport.Table.TableObject Table4;
    public FastReport.Table.TableObject Table5;
    public FastReport.Table.TableObject Table6;
    public FastReport.Table.TableObject Table7;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text10;
    public FastReport.TextObject Text100;
    public FastReport.TextObject Text101;
    public FastReport.TextObject Text102;
    public FastReport.TextObject Text103;
    public FastReport.TextObject Text104;
    public FastReport.TextObject Text105;
    public FastReport.TextObject Text106;
    public FastReport.TextObject Text107;
    public FastReport.TextObject Text108;
    public FastReport.TextObject Text109;
    public FastReport.TextObject Text11;
    public FastReport.TextObject Text110;
    public FastReport.TextObject Text111;
    public FastReport.TextObject Text112;
    public FastReport.TextObject Text113;
    public FastReport.TextObject Text114;
    public FastReport.TextObject Text115;
    public FastReport.TextObject Text116;
    public FastReport.TextObject Text117;
    public FastReport.TextObject Text118;
    public FastReport.TextObject Text119;
    public FastReport.TextObject Text12;
    public FastReport.TextObject Text120;
    public FastReport.TextObject Text121;
    public FastReport.TextObject Text122;
    public FastReport.TextObject Text123;
    public FastReport.TextObject Text124;
    public FastReport.TextObject Text125;
    public FastReport.TextObject Text126;
    public FastReport.TextObject Text127;
    public FastReport.TextObject Text128;
    public FastReport.TextObject Text129;
    public FastReport.TextObject Text13;
    public FastReport.TextObject Text130;
    public FastReport.TextObject Text131;
    public FastReport.TextObject Text132;
    public FastReport.TextObject Text133;
    public FastReport.TextObject Text134;
    public FastReport.TextObject Text135;
    public FastReport.TextObject Text136;
    public FastReport.TextObject Text137;
    public FastReport.TextObject Text138;
    public FastReport.TextObject Text139;
    public FastReport.TextObject Text14;
    public FastReport.TextObject Text140;
    public FastReport.TextObject Text141;
    public FastReport.TextObject Text142;
    public FastReport.TextObject Text143;
    public FastReport.TextObject Text144;
    public FastReport.TextObject Text145;
    public FastReport.TextObject Text146;
    public FastReport.TextObject Text147;
    public FastReport.TextObject Text148;
    public FastReport.TextObject Text149;
    public FastReport.TextObject Text15;
    public FastReport.TextObject Text150;
    public FastReport.TextObject Text151;
    public FastReport.TextObject Text152;
    public FastReport.TextObject Text153;
    public FastReport.TextObject Text154;
    public FastReport.TextObject Text155;
    public FastReport.TextObject Text156;
    public FastReport.TextObject Text157;
    public FastReport.TextObject Text158;
    public FastReport.TextObject Text159;
    public FastReport.TextObject Text16;
    public FastReport.TextObject Text160;
    public FastReport.TextObject Text161;
    public FastReport.TextObject Text162;
    public FastReport.TextObject Text163;
    public FastReport.TextObject Text164;
    public FastReport.TextObject Text165;
    public FastReport.TextObject Text166;
    public FastReport.TextObject Text167;
    public FastReport.TextObject Text168;
    public FastReport.TextObject Text169;
    public FastReport.TextObject Text17;
    public FastReport.TextObject Text170;
    public FastReport.TextObject Text171;
    public FastReport.TextObject Text172;
    public FastReport.TextObject Text173;
    public FastReport.TextObject Text174;
    public FastReport.TextObject Text175;
    public FastReport.TextObject Text176;
    public FastReport.TextObject Text177;
    public FastReport.TextObject Text178;
    public FastReport.TextObject Text179;
    public FastReport.TextObject Text18;
    public FastReport.TextObject Text180;
    public FastReport.TextObject Text181;
    public FastReport.TextObject Text182;
    public FastReport.TextObject Text183;
    public FastReport.TextObject Text184;
    public FastReport.TextObject Text185;
    public FastReport.TextObject Text186;
    public FastReport.TextObject Text187;
    public FastReport.TextObject Text188;
    public FastReport.TextObject Text189;
    public FastReport.TextObject Text19;
    public FastReport.TextObject Text190;
    public FastReport.TextObject Text191;
    public FastReport.TextObject Text192;
    public FastReport.TextObject Text193;
    public FastReport.TextObject Text194;
    public FastReport.TextObject Text195;
    public FastReport.TextObject Text196;
    public FastReport.TextObject Text197;
    public FastReport.TextObject Text198;
    public FastReport.TextObject Text199;
    public FastReport.TextObject Text2;
    public FastReport.TextObject Text20;
    public FastReport.TextObject Text200;
    public FastReport.TextObject Text201;
    public FastReport.TextObject Text202;
    public FastReport.TextObject Text203;
    public FastReport.TextObject Text204;
    public FastReport.TextObject Text205;
    public FastReport.TextObject Text206;
    public FastReport.TextObject Text207;
    public FastReport.TextObject Text208;
    public FastReport.TextObject Text209;
    public FastReport.TextObject Text21;
    public FastReport.TextObject Text210;
    public FastReport.TextObject Text211;
    public FastReport.TextObject Text212;
    public FastReport.TextObject Text213;
    public FastReport.TextObject Text214;
    public FastReport.TextObject Text215;
    public FastReport.TextObject Text216;
    public FastReport.TextObject Text217;
    public FastReport.TextObject Text218;
    public FastReport.TextObject Text219;
    public FastReport.TextObject Text22;
    public FastReport.TextObject Text220;
    public FastReport.TextObject Text221;
    public FastReport.TextObject Text222;
    public FastReport.TextObject Text223;
    public FastReport.TextObject Text224;
    public FastReport.TextObject Text225;
    public FastReport.TextObject Text226;
    public FastReport.TextObject Text227;
    public FastReport.TextObject Text228;
    public FastReport.TextObject Text229;
    public FastReport.TextObject Text23;
    public FastReport.TextObject Text230;
    public FastReport.TextObject Text231;
    public FastReport.TextObject Text232;
    public FastReport.TextObject Text233;
    public FastReport.TextObject Text234;
    public FastReport.TextObject Text235;
    public FastReport.TextObject Text236;
    public FastReport.TextObject Text237;
    public FastReport.TextObject Text238;
    public FastReport.TextObject Text239;
    public FastReport.TextObject Text24;
    public FastReport.TextObject Text240;
    public FastReport.TextObject Text241;
    public FastReport.TextObject Text242;
    public FastReport.TextObject Text243;
    public FastReport.TextObject Text244;
    public FastReport.TextObject Text245;
    public FastReport.TextObject Text246;
    public FastReport.TextObject Text247;
    public FastReport.TextObject Text248;
    public FastReport.TextObject Text249;
    public FastReport.TextObject Text25;
    public FastReport.TextObject Text250;
    public FastReport.TextObject Text251;
    public FastReport.TextObject Text252;
    public FastReport.TextObject Text253;
    public FastReport.TextObject Text254;
    public FastReport.TextObject Text255;
    public FastReport.TextObject Text256;
    public FastReport.TextObject Text257;
    public FastReport.TextObject Text258;
    public FastReport.TextObject Text259;
    public FastReport.TextObject Text26;
    public FastReport.TextObject Text260;
    public FastReport.TextObject Text261;
    public FastReport.TextObject Text262;
    public FastReport.TextObject Text263;
    public FastReport.TextObject Text264;
    public FastReport.TextObject Text265;
    public FastReport.TextObject Text266;
    public FastReport.TextObject Text267;
    public FastReport.TextObject Text268;
    public FastReport.TextObject Text269;
    public FastReport.TextObject Text27;
    public FastReport.TextObject Text270;
    public FastReport.TextObject Text271;
    public FastReport.TextObject Text272;
    public FastReport.TextObject Text273;
    public FastReport.TextObject Text274;
    public FastReport.TextObject Text275;
    public FastReport.TextObject Text276;
    public FastReport.TextObject Text277;
    public FastReport.TextObject Text278;
    public FastReport.TextObject Text279;
    public FastReport.TextObject Text28;
    public FastReport.TextObject Text280;
    public FastReport.TextObject Text281;
    public FastReport.TextObject Text282;
    public FastReport.TextObject Text283;
    public FastReport.TextObject Text284;
    public FastReport.TextObject Text285;
    public FastReport.TextObject Text286;
    public FastReport.TextObject Text287;
    public FastReport.TextObject Text288;
    public FastReport.TextObject Text289;
    public FastReport.TextObject Text29;
    public FastReport.TextObject Text290;
    public FastReport.TextObject Text291;
    public FastReport.TextObject Text3;
    public FastReport.TextObject Text30;
    public FastReport.TextObject Text31;
    public FastReport.TextObject Text32;
    public FastReport.TextObject Text33;
    public FastReport.TextObject Text34;
    public FastReport.TextObject Text35;
    public FastReport.TextObject Text36;
    public FastReport.TextObject Text37;
    public FastReport.TextObject Text38;
    public FastReport.TextObject Text39;
    public FastReport.TextObject Text4;
    public FastReport.TextObject Text40;
    public FastReport.TextObject Text41;
    public FastReport.TextObject Text42;
    public FastReport.TextObject Text43;
    public FastReport.TextObject Text44;
    public FastReport.TextObject Text45;
    public FastReport.TextObject Text46;
    public FastReport.TextObject Text47;
    public FastReport.TextObject Text48;
    public FastReport.TextObject Text49;
    public FastReport.TextObject Text5;
    public FastReport.TextObject Text50;
    public FastReport.TextObject Text51;
    public FastReport.TextObject Text52;
    public FastReport.TextObject Text53;
    public FastReport.TextObject Text54;
    public FastReport.TextObject Text55;
    public FastReport.TextObject Text56;
    public FastReport.TextObject Text57;
    public FastReport.TextObject Text58;
    public FastReport.TextObject Text59;
    public FastReport.TextObject Text6;
    public FastReport.TextObject Text60;
    public FastReport.TextObject Text61;
    public FastReport.TextObject Text62;
    public FastReport.TextObject Text63;
    public FastReport.TextObject Text64;
    public FastReport.TextObject Text65;
    public FastReport.TextObject Text66;
    public FastReport.TextObject Text67;
    public FastReport.TextObject Text68;
    public FastReport.TextObject Text69;
    public FastReport.TextObject Text7;
    public FastReport.TextObject Text70;
    public FastReport.TextObject Text71;
    public FastReport.TextObject Text72;
    public FastReport.TextObject Text73;
    public FastReport.TextObject Text74;
    public FastReport.TextObject Text75;
    public FastReport.TextObject Text76;
    public FastReport.TextObject Text77;
    public FastReport.TextObject Text78;
    public FastReport.TextObject Text79;
    public FastReport.TextObject Text8;
    public FastReport.TextObject Text80;
    public FastReport.TextObject Text81;
    public FastReport.TextObject Text82;
    public FastReport.TextObject Text83;
    public FastReport.TextObject Text84;
    public FastReport.TextObject Text85;
    public FastReport.TextObject Text86;
    public FastReport.TextObject Text87;
    public FastReport.TextObject Text88;
    public FastReport.TextObject Text89;
    public FastReport.TextObject Text9;
    public FastReport.TextObject Text90;
    public FastReport.TextObject Text91;
    public FastReport.TextObject Text92;
    public FastReport.TextObject Text93;
    public FastReport.TextObject Text94;
    public FastReport.TextObject Text95;
    public FastReport.TextObject Text96;
    public FastReport.TextObject Text97;
    public FastReport.TextObject Text98;
    public FastReport.TextObject Text99;
    private object Sum(TableCell cell)
    {
      return cell.Table.Sum(cell);
    }

    private object Min(TableCell cell)
    {
      return cell.Table.Min(cell);
    }

    private object Max(TableCell cell)
    {
      return cell.Table.Max(cell);
    }

    private object Avg(TableCell cell)
    {
      return cell.Table.Avg(cell);
    }

    private object Count(TableCell cell)
    {
      return cell.Table.Count(cell);
    }

    protected override object CalcExpression(string expression, Variant Value)
    {
      if (expression == "IIf([R_PQM.CP007]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP007"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP008]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP008"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP011]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP011"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP012]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP012"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP014]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP014"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP015]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP015"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP016]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP016"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP026]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP026"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP027]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP027"))!="",true,false);
      if (expression == "IIf([R_PQM.CP032]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP032"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP160]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP160"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP036]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP036"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP161]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP161"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP040]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP040"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP162]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP162"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP163]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP163"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP045]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP045"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP164]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP164"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP049]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP049"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP173]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP173"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP165]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP165"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP174]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP174"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP175]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP175"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP153]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP153"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP062]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP062"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP063]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP063"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP064]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP064"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP065]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP065"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP066]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP066"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP067]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP067"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP068]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP068"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP069]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP069"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP070]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP070"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP071]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP071"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP075]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP075"))!="",true,false);
      if (expression == "IIf([R_PQM.CP092]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP092"))!="",true,false);
      if (expression == "IIf([R_PQM.CP086]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP086"))!="",true,false);
      if (expression == "IIf([R_PQM.CP084]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP084"))!="",true,false);
      if (expression == "IIf([R_PQM.CP080]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP080"))!="",true,false);
      if (expression == "IIf([R_PQM.CP094]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP094"))!="",true,false);
      if (expression == "IIf([R_PQM.CP078]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP078"))!="",true,false);
      if (expression == "IIf([R_PQM.CP088]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP088"))!="",true,false);
      if (expression == "IIf([R_PQM.CP096]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP096"))!="",true,false);
      if (expression == "IIf([R_PQM.CP082]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP082"))!="",true,false);
      if (expression == "IIf([R_PQM.CP090]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP090"))!="",true,false);
      if (expression == "IIf([R_PQM.CP166]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP166"))!="",true,false);
      if (expression == "IIf([R_PQM.CP167]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP167"))!="",true,false);
      if (expression == "IIf([R_PQM.CP168]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP168"))!="",true,false);
      if (expression == "IIf([R_PQM.CP169]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP169"))!="",true,false);
      if (expression == "IIf([R_PQM.CP170]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP170"))!="",true,false);
      if (expression == "IIf([R_PQM.CP171]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP171"))!="",true,false);
      if (expression == "IIf([R_PQM.CP172]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP172"))!="",true,false);
      if (expression == "IIf([R_PQM.CP112]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP112"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP113]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP113"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP114]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP114"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP115]>0,true,false)")
        return IIf(((Decimal)Report.GetColumnValue("R_PQM.CP115"))>0,true,false);
      if (expression == "IIf([R_PQM.CP116]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP116"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP117]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP117"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP118]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP118"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP119]>0,true,false)")
        return IIf(((Decimal)Report.GetColumnValue("R_PQM.CP119"))>0,true,false);
      if (expression == "IIf([R_PQM.CP120]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP120"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP121]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP121"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP122]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP122"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP123]>0,true,false)")
        return IIf(((Decimal)Report.GetColumnValue("R_PQM.CP123"))>0,true,false);
      if (expression == "IIf([R_PQM.CP124]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP124"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP125]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP125"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP126]==\"T\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP126"))=="T",true,false);
      if (expression == "IIf([R_PQM.CP127]!=\"\",true,false)")
        return IIf(((String)Report.GetColumnValue("R_PQM.CP127"))!="",true,false);
      return null;
    }

    private SByte Abs(SByte value)
    {
      return System.Math.Abs(value);
    }

    private Int16 Abs(Int16 value)
    {
      return System.Math.Abs(value);
    }

    private Int32 Abs(Int32 value)
    {
      return System.Math.Abs(value);
    }

    private Int64 Abs(Int64 value)
    {
      return System.Math.Abs(value);
    }

    private Single Abs(Single value)
    {
      return System.Math.Abs(value);
    }

    private Double Abs(Double value)
    {
      return System.Math.Abs(value);
    }

    private Decimal Abs(Decimal value)
    {
      return System.Math.Abs(value);
    }

    private Double Acos(Double d)
    {
      return System.Math.Acos(d);
    }

    private Double Asin(Double d)
    {
      return System.Math.Asin(d);
    }

    private Double Atan(Double d)
    {
      return System.Math.Atan(d);
    }

    private Double Ceiling(Double a)
    {
      return System.Math.Ceiling(a);
    }

    private Decimal Ceiling(Decimal d)
    {
      return System.Math.Ceiling(d);
    }

    private Double Cos(Double d)
    {
      return System.Math.Cos(d);
    }

    private Double Exp(Double d)
    {
      return System.Math.Exp(d);
    }

    private Double Floor(Double d)
    {
      return System.Math.Floor(d);
    }

    private Decimal Floor(Decimal d)
    {
      return System.Math.Floor(d);
    }

    private Double Log(Double d)
    {
      return System.Math.Log(d);
    }

    private Int32 Maximum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int64 Maximum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Single Maximum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Double Maximum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Decimal Maximum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int32 Minimum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Int64 Minimum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Single Minimum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Minimum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Decimal Minimum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Round(Double a)
    {
      return System.Math.Round(a);
    }

    private Decimal Round(Decimal d)
    {
      return System.Math.Round(d);
    }

    private Double Round(Double value, Int32 digits)
    {
      return System.Math.Round(value, digits);
    }

    private Decimal Round(Decimal d, Int32 decimals)
    {
      return System.Math.Round(d, decimals);
    }

    private Double Sin(Double a)
    {
      return System.Math.Sin(a);
    }

    private Double Sqrt(Double d)
    {
      return System.Math.Sqrt(d);
    }

    private Double Tan(Double a)
    {
      return System.Math.Tan(a);
    }

    private Double Truncate(Double d)
    {
      return System.Math.Truncate(d);
    }

    private Decimal Truncate(Decimal d)
    {
      return System.Math.Truncate(d);
    }

    private Int32 Asc(Char c)
    {
      return FastReport.Functions.StdFunctions.Asc(c);
    }

    private Char Chr(Int32 i)
    {
      return FastReport.Functions.StdFunctions.Chr(i);
    }

    private String Insert(String s, Int32 startIndex, String value)
    {
      return FastReport.Functions.StdFunctions.Insert(s, startIndex, value);
    }

    private Int32 Length(String s)
    {
      return FastReport.Functions.StdFunctions.Length(s);
    }

    private String LowerCase(String s)
    {
      return FastReport.Functions.StdFunctions.LowerCase(s);
    }

    private String PadLeft(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth);
    }

    private String PadLeft(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth, paddingChar);
    }

    private String PadRight(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth);
    }

    private String PadRight(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth, paddingChar);
    }

    private String Remove(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex);
    }

    private String Remove(String s, Int32 startIndex, Int32 count)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex, count);
    }

    private String Replace(String s, String oldValue, String newValue)
    {
      return FastReport.Functions.StdFunctions.Replace(s, oldValue, newValue);
    }

    private String Substring(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex);
    }

    private String Substring(String s, Int32 startIndex, Int32 length)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex, length);
    }

    private String TitleCase(String s)
    {
      return FastReport.Functions.StdFunctions.TitleCase(s);
    }

    private String Trim(String s)
    {
      return FastReport.Functions.StdFunctions.Trim(s);
    }

    private String UpperCase(String s)
    {
      return FastReport.Functions.StdFunctions.UpperCase(s);
    }

    private DateTime AddDays(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddDays(date, value);
    }

    private DateTime AddHours(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddHours(date, value);
    }

    private DateTime AddMinutes(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddMinutes(date, value);
    }

    private DateTime AddMonths(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddMonths(date, value);
    }

    private DateTime AddSeconds(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddSeconds(date, value);
    }

    private DateTime AddYears(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddYears(date, value);
    }

    private TimeSpan DateDiff(DateTime date1, DateTime date2)
    {
      return FastReport.Functions.StdFunctions.DateDiff(date1, date2);
    }

    private DateTime DateSerial(Int32 year, Int32 month, Int32 day)
    {
      return FastReport.Functions.StdFunctions.DateSerial(year, month, day);
    }

    private Int32 Day(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Day(date);
    }

    private String DayOfWeek(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfWeek(date);
    }

    private Int32 DayOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfYear(date);
    }

    private Int32 DaysInMonth(Int32 year, Int32 month)
    {
      return FastReport.Functions.StdFunctions.DaysInMonth(year, month);
    }

    private Int32 Hour(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Hour(date);
    }

    private Int32 Minute(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Minute(date);
    }

    private Int32 Month(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Month(date);
    }

    private String MonthName(Int32 month)
    {
      return FastReport.Functions.StdFunctions.MonthName(month);
    }

    private Int32 Second(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Second(date);
    }

    private Int32 WeekOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.WeekOfYear(date);
    }

    private Int32 Year(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Year(date);
    }

    private String Format(String format, params Object[] args)
    {
      return FastReport.Functions.StdFunctions.Format(format, args);
    }

    private String FormatCurrency(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value);
    }

    private String FormatCurrency(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value, decimalDigits);
    }

    private String FormatDateTime(DateTime value)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value);
    }

    private String FormatDateTime(DateTime value, String format)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value, format);
    }

    private String FormatNumber(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value);
    }

    private String FormatNumber(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value, decimalDigits);
    }

    private String FormatPercent(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value);
    }

    private String FormatPercent(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value, decimalDigits);
    }

    private Boolean ToBoolean(Object value)
    {
      return System.Convert.ToBoolean(value);
    }

    private Byte ToByte(Object value)
    {
      return System.Convert.ToByte(value);
    }

    private Char ToChar(Object value)
    {
      return System.Convert.ToChar(value);
    }

    private DateTime ToDateTime(Object value)
    {
      return System.Convert.ToDateTime(value);
    }

    private Decimal ToDecimal(Object value)
    {
      return System.Convert.ToDecimal(value);
    }

    private Double ToDouble(Object value)
    {
      return System.Convert.ToDouble(value);
    }

    private Int32 ToInt32(Object value)
    {
      return System.Convert.ToInt32(value);
    }

    private String ToRoman(Object value)
    {
      return FastReport.Functions.StdFunctions.ToRoman(value);
    }

    private Single ToSingle(Object value)
    {
      return System.Convert.ToSingle(value);
    }

    private String ToString(Object value)
    {
      return System.Convert.ToString(value);
    }

    private String ToWords(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWords(value);
    }

    private String ToWords(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, currencyName);
    }

    private String ToWords(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, one, many);
    }

    private String ToWordsEnGb(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value);
    }

    private String ToWordsEnGb(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, currencyName);
    }

    private String ToWordsEnGb(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, one, many);
    }

    private String ToWordsEs(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value);
    }

    private String ToWordsEs(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, currencyName);
    }

    private String ToWordsEs(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, one, many);
    }

    private String ToWordsRu(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value);
    }

    private String ToWordsRu(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, currencyName);
    }

    private String ToWordsRu(Object value, Boolean male, String one, String two, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, male, one, two, many);
    }

    private Object Choose(Double index, params Object[] choice)
    {
      return FastReport.Functions.StdFunctions.Choose(index, choice);
    }

    private Object IIf(Boolean expression, Object truePart, Object falsePart)
    {
      return FastReport.Functions.StdFunctions.IIf(expression, truePart, falsePart);
    }

    private Object Switch(params Object[] expressions)
    {
      return FastReport.Functions.StdFunctions.Switch(expressions);
    }

    private Boolean IsNull(String name)
    {
      return FastReport.Functions.StdFunctions.IsNull(Report, name);
    }

    private void InitializeComponent()
    {
      string reportString = 
        "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Report ScriptLanguage=\"CSharp\" ReportI" +
        "nfo.Created=\"12/29/2015 14:44:47\" ReportInfo.Modified=\"12/30/2015 18:35:16\" Repo" +
        "rtInfo.CreatorVersion=\"2013.2.5.0\">\r\n  <Dictionary>\r\n    <OleDbDataConnection Na" +
        "me=\"Connection1\" ConnectionString=\"rijcmlqVzFGsc+BVENiWJhr/EarGlrJ0V2eD49/23aASH" +
        "u9CzkLXmK1vG22g18L7rYYWBO+4SBv7MsTeEOHQWXAF5hzGJQ06EX3i2VRb+WzKNuPUGxsHxZbn5B/d/" +
        "PZo0FN5hGi7FASw+6/f6oV/SHlp+QHLg==\">\r\n      <TableDataSource Name=\"Table8\" Alias" +
        "=\"R_PQMS\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"SELECT CP156,CP1" +
        "57,CP158,CP159 FROM R_PQM\">\r\n        <Column Name=\"CP156\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"CP157\" DataType=\"System.String\"/>\r\n        <Column N" +
        "ame=\"CP158\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"CP159\" DataType=\"Sy" +
        "stem.String\"/>\r\n      </TableDataSource>\r\n    </OleDbDataConnection>\r\n    <OleDb" +
        "DataConnection Name=\"Connection\" ConnectionString=\"rijcmlqVzFGsc+BVENiWJhr/EarGl" +
        "rJ0V2eD49/23aASHu9CzkLXmK1vG22g18L7rYYWBO+4SBv7MsTeEOHQWXAF5hzGJQ06EX3i2VRb+WzKN";
      reportString += "uPUGxsHxZbn5B/d/PZo0FN5hGiF25bS3bfJPgiy7DhR+Hp1Q==\">\r\n      <TableDataSource Nam" +
        "e=\"Table9\" Alias=\"R_PQM\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"S" +
        "ELECT PQF03,PQF04,DFA002,CP003,CP004,CP005,CP006,CP009,CP007,CP008,CP011,CP012,C" +
        "P014,CP015,CP016,CP026,CP027,CP028,CP029,CP031,CP032, CP033, CP034, CP035, CP036" +
        ", CP037, CP039, CP040, CP041, CP043, CP044, CP045, CP047, CP048, CP049, CP051, C" +
        "P052, CP053, CP055,CP056, CP057, CP059, CP060, CP061, CP062, CP063, CP064, CP065" +
        ", CP066, CP067, CP068, CP069, CP070, CP071, CP072, CP073, CP074, CP075, CP076, C" +
        "P078, CP079,CP080, CP081, CP082, CP083, CP084, CP085, CP086, CP087, CP088, CP089" +
        ", CP090, CP091, CP092, CP093, CP094, CP095, CP096, CP097, CP166, CP098, CP099, C" +
        "P167, CP100, CP101,CP168, CP102, CP103, CP169, CP104, CP105, CP170, CP106, CP107" +
        ", CP171, CP108, CP109, CP172, CP110, CP111, CP112, CP113, CP114, CP115, CP116, C" +
        "P117, CP118, CP119,CP120, CP121, CP122, CP123, CP124, CP125, CP126, CP127, CP128" +
        ", CP129, CP130, CP131, CP132, CP133, CP134, CP135, CP136, CP137, CP138, CP139, C";
      reportString += "P140, CP141, CP142, CP143,CP144, CP145, CP146, CP147, CP148, CP149, CP150, CP151" +
        ", CP152, CP153, CP154, CP155,CP160,CP161,CP162,CP163,CP164,CP165,CP173,CP174,CP1" +
        "75 FROM R_PQM A, R_PQF B, TPADFA C WHERE A.CP001 = B.PQF01 AND B.PQF11 = C.DFA00" +
        "1\">\r\n        <Column Name=\"PQF03\" DataType=\"System.String\"/>\r\n        <Column Na" +
        "me=\"PQF04\" DataType=\"System.String\"/>\r\n        <Column Name=\"DFA002\" DataType=\"S" +
        "ystem.String\"/>\r\n        <Column Name=\"CP003\" DataType=\"System.Byte[]\" BindableC" +
        "ontrol=\"Picture\"/>\r\n        <Column Name=\"CP004\" DataType=\"System.Byte[]\" Bindab" +
        "leControl=\"Picture\"/>\r\n        <Column Name=\"CP005\" DataType=\"System.Byte[]\" Bin" +
        "dableControl=\"Picture\"/>\r\n        <Column Name=\"CP006\" DataType=\"System.Byte[]\" " +
        "BindableControl=\"Picture\"/>\r\n        <Column Name=\"CP009\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"CP007\" DataType=\"System.String\"/>\r\n        <Column N" +
        "ame=\"CP008\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP011\" DataType=\"S";
      reportString += "ystem.String\"/>\r\n        <Column Name=\"CP012\" DataType=\"System.String\"/>\r\n      " +
        "  <Column Name=\"CP014\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP015\" " +
        "DataType=\"System.String\"/>\r\n        <Column Name=\"CP016\" DataType=\"System.String" +
        "\"/>\r\n        <Column Name=\"CP026\" DataType=\"System.String\"/>\r\n        <Column Na" +
        "me=\"CP027\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP028\" DataType=\"Sy" +
        "stem.String\"/>\r\n        <Column Name=\"CP029\" DataType=\"System.String\"/>\r\n       " +
        " <Column Name=\"CP031\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP032\" D" +
        "ataType=\"System.String\"/>\r\n        <Column Name=\"CP033\" DataType=\"System.String\"" +
        "/>\r\n        <Column Name=\"CP034\" DataType=\"System.String\"/>\r\n        <Column Nam" +
        "e=\"CP035\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP036\" DataType=\"Sys" +
        "tem.String\"/>\r\n        <Column Name=\"CP037\" DataType=\"System.String\"/>\r\n        " +
        "<Column Name=\"CP039\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP040\" Da";
      reportString += "taType=\"System.String\"/>\r\n        <Column Name=\"CP041\" DataType=\"System.String\"/" +
        ">\r\n        <Column Name=\"CP043\" DataType=\"System.String\"/>\r\n        <Column Name" +
        "=\"CP044\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP045\" DataType=\"Syst" +
        "em.String\"/>\r\n        <Column Name=\"CP047\" DataType=\"System.String\"/>\r\n        <" +
        "Column Name=\"CP048\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP049\" Dat" +
        "aType=\"System.String\"/>\r\n        <Column Name=\"CP051\" DataType=\"System.String\"/>" +
        "\r\n        <Column Name=\"CP052\" DataType=\"System.String\"/>\r\n        <Column Name=" +
        "\"CP053\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP055\" DataType=\"Syste" +
        "m.String\"/>\r\n        <Column Name=\"CP056\" DataType=\"System.String\"/>\r\n        <C" +
        "olumn Name=\"CP057\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP059\" Data" +
        "Type=\"System.String\"/>\r\n        <Column Name=\"CP060\" DataType=\"System.String\"/>\r" +
        "\n        <Column Name=\"CP061\" DataType=\"System.String\"/>\r\n        <Column Name=\"";
      reportString += "CP062\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP063\" DataType=\"System" +
        ".String\"/>\r\n        <Column Name=\"CP064\" DataType=\"System.String\"/>\r\n        <Co" +
        "lumn Name=\"CP065\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP066\" DataT" +
        "ype=\"System.String\"/>\r\n        <Column Name=\"CP067\" DataType=\"System.String\"/>\r\n" +
        "        <Column Name=\"CP068\" DataType=\"System.String\"/>\r\n        <Column Name=\"C" +
        "P069\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP070\" DataType=\"System." +
        "String\"/>\r\n        <Column Name=\"CP071\" DataType=\"System.String\"/>\r\n        <Col" +
        "umn Name=\"CP072\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"CP073\" DataTyp" +
        "e=\"System.Int32\"/>\r\n        <Column Name=\"CP074\" DataType=\"System.Int32\"/>\r\n    " +
        "    <Column Name=\"CP075\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP076" +
        "\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP078\" DataType=\"System.Stri" +
        "ng\"/>\r\n        <Column Name=\"CP079\" DataType=\"System.String\"/>\r\n        <Column ";
      reportString += "Name=\"CP080\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP081\" DataType=\"" +
        "System.String\"/>\r\n        <Column Name=\"CP082\" DataType=\"System.String\"/>\r\n     " +
        "   <Column Name=\"CP083\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP084\"" +
        " DataType=\"System.String\"/>\r\n        <Column Name=\"CP085\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"CP086\" DataType=\"System.String\"/>\r\n        <Column N" +
        "ame=\"CP087\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP088\" DataType=\"S" +
        "ystem.String\"/>\r\n        <Column Name=\"CP089\" DataType=\"System.String\"/>\r\n      " +
        "  <Column Name=\"CP090\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP091\" " +
        "DataType=\"System.String\"/>\r\n        <Column Name=\"CP092\" DataType=\"System.String" +
        "\"/>\r\n        <Column Name=\"CP093\" DataType=\"System.String\"/>\r\n        <Column Na" +
        "me=\"CP094\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP095\" DataType=\"Sy" +
        "stem.String\"/>\r\n        <Column Name=\"CP096\" DataType=\"System.String\"/>\r\n       ";
      reportString += " <Column Name=\"CP097\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP166\" D" +
        "ataType=\"System.String\"/>\r\n        <Column Name=\"CP098\" DataType=\"System.String\"" +
        "/>\r\n        <Column Name=\"CP099\" DataType=\"System.String\"/>\r\n        <Column Nam" +
        "e=\"CP167\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP100\" DataType=\"Sys" +
        "tem.String\"/>\r\n        <Column Name=\"CP101\" DataType=\"System.String\"/>\r\n        " +
        "<Column Name=\"CP168\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP102\" Da" +
        "taType=\"System.String\"/>\r\n        <Column Name=\"CP103\" DataType=\"System.String\"/" +
        ">\r\n        <Column Name=\"CP169\" DataType=\"System.String\"/>\r\n        <Column Name" +
        "=\"CP104\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP105\" DataType=\"Syst" +
        "em.String\"/>\r\n        <Column Name=\"CP170\" DataType=\"System.String\"/>\r\n        <" +
        "Column Name=\"CP106\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP107\" Dat" +
        "aType=\"System.String\"/>\r\n        <Column Name=\"CP171\" DataType=\"System.String\"/>";
      reportString += "\r\n        <Column Name=\"CP108\" DataType=\"System.String\"/>\r\n        <Column Name=" +
        "\"CP109\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP172\" DataType=\"Syste" +
        "m.String\"/>\r\n        <Column Name=\"CP110\" DataType=\"System.String\"/>\r\n        <C" +
        "olumn Name=\"CP111\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP112\" Data" +
        "Type=\"System.String\"/>\r\n        <Column Name=\"CP113\" DataType=\"System.String\"/>\r" +
        "\n        <Column Name=\"CP114\" DataType=\"System.String\"/>\r\n        <Column Name=\"" +
        "CP115\" DataType=\"System.Decimal\"/>\r\n        <Column Name=\"CP116\" DataType=\"Syste" +
        "m.String\"/>\r\n        <Column Name=\"CP117\" DataType=\"System.String\"/>\r\n        <C" +
        "olumn Name=\"CP118\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP119\" Data" +
        "Type=\"System.Decimal\"/>\r\n        <Column Name=\"CP120\" DataType=\"System.String\"/>" +
        "\r\n        <Column Name=\"CP121\" DataType=\"System.String\"/>\r\n        <Column Name=" +
        "\"CP122\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP123\" DataType=\"Syste";
      reportString += "m.Decimal\"/>\r\n        <Column Name=\"CP124\" DataType=\"System.String\"/>\r\n        <" +
        "Column Name=\"CP125\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP126\" Dat" +
        "aType=\"System.String\"/>\r\n        <Column Name=\"CP127\" DataType=\"System.String\"/>" +
        "\r\n        <Column Name=\"CP128\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"" +
        "CP129\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP130\" DataType=\"System" +
        ".String\"/>\r\n        <Column Name=\"CP131\" DataType=\"System.String\"/>\r\n        <Co" +
        "lumn Name=\"CP132\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP133\" DataT" +
        "ype=\"System.Int32\"/>\r\n        <Column Name=\"CP134\" DataType=\"System.String\"/>\r\n " +
        "       <Column Name=\"CP135\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP" +
        "136\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP137\" DataType=\"System.S" +
        "tring\"/>\r\n        <Column Name=\"CP138\" DataType=\"System.Int32\"/>\r\n        <Colum" +
        "n Name=\"CP139\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP140\" DataType";
      reportString += "=\"System.String\"/>\r\n        <Column Name=\"CP141\" DataType=\"System.String\"/>\r\n   " +
        "     <Column Name=\"CP142\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP14" +
        "3\" DataType=\"System.Int32\"/>\r\n        <Column Name=\"CP144\" DataType=\"System.Stri" +
        "ng\"/>\r\n        <Column Name=\"CP145\" DataType=\"System.String\"/>\r\n        <Column " +
        "Name=\"CP146\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP147\" DataType=\"" +
        "System.String\"/>\r\n        <Column Name=\"CP148\" DataType=\"System.Byte[]\" Bindable" +
        "Control=\"Picture\"/>\r\n        <Column Name=\"CP149\" DataType=\"System.Byte[]\" Binda" +
        "bleControl=\"Picture\"/>\r\n        <Column Name=\"CP150\" DataType=\"System.Byte[]\" Bi" +
        "ndableControl=\"Picture\"/>\r\n        <Column Name=\"CP151\" DataType=\"System.Byte[]\"" +
        " BindableControl=\"Picture\"/>\r\n        <Column Name=\"CP152\" DataType=\"System.Stri" +
        "ng\"/>\r\n        <Column Name=\"CP153\" DataType=\"System.String\"/>\r\n        <Column " +
        "Name=\"CP154\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP155\" DataType=\"";
      reportString += "System.String\"/>\r\n        <Column Name=\"CP160\" DataType=\"System.String\"/>\r\n     " +
        "   <Column Name=\"CP161\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP162\"" +
        " DataType=\"System.String\"/>\r\n        <Column Name=\"CP163\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"CP164\" DataType=\"System.String\"/>\r\n        <Column N" +
        "ame=\"CP165\" DataType=\"System.String\"/>\r\n        <Column Name=\"CP173\" DataType=\"S" +
        "ystem.String\"/>\r\n        <Column Name=\"CP174\" DataType=\"System.String\"/>\r\n      " +
        "  <Column Name=\"CP175\" DataType=\"System.String\"/>\r\n      </TableDataSource>\r\n   " +
        " </OleDbDataConnection>\r\n  </Dictionary>\r\n  <ReportPage Name=\"Page1\">\r\n    <Repo" +
        "rtTitleBand Name=\"ReportTitle1\" Width=\"718.2\" Height=\"1058.4\" CanBreak=\"true\" Gu" +
        "ides=\"1058.4\">\r\n      <TextObject Name=\"Text1\" Left=\"-9.45\" Width=\"727.65\" Heigh" +
        "t=\"28.35\" Text=\"产 品 档 案\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 15.75pt" +
        ", style=Bold\"/>\r\n      <TextObject Name=\"Text2\" Left=\"481.95\" Top=\"28.35\" Width=";
      reportString += "\"94.5\" Height=\"18.9\" Text=\"R_404\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体" +
        ", 9pt, style=Bold\"/>\r\n      <TableObject Name=\"Table1\" Top=\"47.25\" Width=\"718.2\"" +
        " Height=\"226.8\" Border.Lines=\"All\">\r\n        <TableColumn Name=\"Column1\" Width=\"" +
        "119.7\"/>\r\n        <TableColumn Name=\"Column2\" Width=\"119.7\"/>\r\n        <TableCol" +
        "umn Name=\"Column3\" Width=\"119.7\"/>\r\n        <TableColumn Name=\"Column4\" Width=\"1" +
        "19.7\"/>\r\n        <TableColumn Name=\"Column5\" Width=\"119.7\"/>\r\n        <TableColu" +
        "mn Name=\"Column6\" Width=\"119.7\"/>\r\n        <TableRow Name=\"Row1\" Height=\"37.8\">\r" +
        "\n          <TableCell Name=\"Cell1\" Font=\"宋体, 9pt\">\r\n            <TextObject Name" +
        "=\"Text3\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"客户简称\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell" +
        ">\r\n          <TableCell Name=\"Cell2\" Font=\"宋体, 9pt\">\r\n            <TextObject Na" +
        "me=\"Text4\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_P";
      reportString += "QM.DFA002]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n         " +
        " </TableCell>\r\n          <TableCell Name=\"Cell3\" Font=\"宋体, 9pt\">\r\n            <T" +
        "extObject Name=\"Text5\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All" +
        "\" Text=\"产品货号\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n       " +
        "   </TableCell>\r\n          <TableCell Name=\"Cell4\" Font=\"宋体, 9pt\">\r\n            " +
        "<TextObject Name=\"Text6\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"A" +
        "ll\" Text=\"[R_PQM.PQF03]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"" +
        "/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell5\" Font=\"宋体, 9pt\">\r\n " +
        "           <TextObject Name=\"Text7\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Bord" +
        "er.Lines=\"All\" Text=\"产品名称\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5p" +
        "t\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell251\" Font=\"宋体, 9pt\"" +
        ">\r\n            <TextObject Name=\"Text8\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" ";
      reportString += "Border.Lines=\"All\" Text=\"[R_PQM.PQF04]\" HorzAlign=\"Center\" VertAlign=\"Center\" Fo" +
        "nt=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        </TableRow>\r\n        <TableRo" +
        "w Name=\"Row2\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell6\" Font=\"宋体, 9pt\">\r" +
        "\n            <TextObject Name=\"Text9\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Bo" +
        "rder.Lines=\"Left, Top\" Text=\"产品图片：\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"" +
        "宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell7\" Font=\"宋" +
        "体, 9pt\"/>\r\n          <TableCell Name=\"Cell8\" Font=\"宋体, 9pt\"/>\r\n          <TableC" +
        "ell Name=\"Cell9\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell10\" Font=\"宋体, " +
        "9pt\">\r\n            <TextObject Name=\"Text10\" Width=\"119.7\" Height=\"37.8\" Dock=\"F" +
        "ill\" Text=\"产品规格：\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n   " +
        "       </TableCell>\r\n          <TableCell Name=\"Cell252\" Font=\"宋体, 9pt\">\r\n      " +
        "      <TextObject Name=\"Text11\" Width=\"119.7\" Height=\"37.8\" Dock=\"Fill\" Border.L";
      reportString += "ines=\"Right\" Text=\"[R_PQM.CP009]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体" +
        ", 10.5pt\"/>\r\n          </TableCell>\r\n        </TableRow>\r\n        <TableRow Name" +
        "=\"Row3\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell11\" Font=\"宋体, 9pt\" ColSpa" +
        "n=\"6\" RowSpan=\"4\">\r\n            <PictureObject Name=\"Picture1\" Left=\"47.25\" Top=" +
        "\"9.45\" Width=\"122.85\" Height=\"85.05\" SizeMode=\"StretchImage\" DataColumn=\"R_PQM.C" +
        "P003\"/>\r\n            <PictureObject Name=\"Picture2\" Left=\"226.8\" Top=\"9.45\" Widt" +
        "h=\"122.85\" Height=\"85.05\" SizeMode=\"StretchImage\" DataColumn=\"R_PQM.CP004\"/>\r\n  " +
        "          <PictureObject Name=\"Picture3\" Left=\"396.9\" Top=\"9.45\" Width=\"122.85\" " +
        "Height=\"85.05\" SizeMode=\"StretchImage\" DataColumn=\"R_PQM.CP005\"/>\r\n            <" +
        "PictureObject Name=\"Picture4\" Left=\"557.55\" Top=\"9.45\" Width=\"122.85\" Height=\"85" +
        ".05\" SizeMode=\"StretchImage\" DataColumn=\"R_PQM.CP006\"/>\r\n            <TextObject" +
        " Name=\"Text12\" Left=\"47.25\" Top=\"113.4\" Width=\"47.25\" Height=\"18.9\" Text=\"正视\" Ho";
      reportString += "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject" +
        " Name=\"Text13\" Left=\"226.8\" Top=\"113.4\" Width=\"47.25\" Height=\"18.9\" Text=\"俯视\" Ho" +
        "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject" +
        " Name=\"Text14\" Left=\"396.9\" Top=\"113.4\" Width=\"37.8\" Height=\"18.9\" Text=\"45°\" Ho" +
        "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject" +
        " Name=\"Text15\" Left=\"557.55\" Top=\"113.4\" Width=\"75.6\" Height=\"18.9\" Text=\"完整包装\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell" +
        ">\r\n          <TableCell Name=\"Cell12\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Nam" +
        "e=\"Cell13\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell14\" Font=\"宋体, 9pt\"/>" +
        "\r\n          <TableCell Name=\"Cell15\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name" +
        "=\"Cell253\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row4\" " +
        "Height=\"37.8\">\r\n          <TableCell Name=\"Cell16\" Font=\"宋体, 9pt\"/>\r\n          <";
      reportString += "TableCell Name=\"Cell17\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell18\" Fon" +
        "t=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell19\" Font=\"宋体, 9pt\"/>\r\n          <T" +
        "ableCell Name=\"Cell20\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell254\" Fon" +
        "t=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row5\" Height=\"37.8\">" +
        "\r\n          <TableCell Name=\"Cell21\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name" +
        "=\"Cell22\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell23\" Font=\"宋体, 9pt\"/>\r" +
        "\n          <TableCell Name=\"Cell24\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=" +
        "\"Cell25\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell255\" Font=\"宋体, 9pt\"/>\r" +
        "\n        </TableRow>\r\n        <TableRow Name=\"Row6\" Height=\"37.8\">\r\n          <T" +
        "ableCell Name=\"Cell26\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell27\" Font" +
        "=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell28\" Font=\"宋体, 9pt\"/>\r\n          <Ta" +
        "bleCell Name=\"Cell29\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell30\" Font=";
      reportString += "\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell256\" Font=\"宋体, 9pt\"/>\r\n        </Tab" +
        "leRow>\r\n      </TableObject>\r\n      <TableObject Name=\"Table2\" Top=\"274.05\" Widt" +
        "h=\"718.2\" Height=\"378\" Border.Lines=\"All\">\r\n        <TableColumn Name=\"Column7\" " +
        "Width=\"68.04\"/>\r\n        <TableColumn Name=\"Column8\" Width=\"96.39\"/>\r\n        <T" +
        "ableColumn Name=\"Column9\" Width=\"115.29\"/>\r\n        <TableColumn Name=\"Column10\"" +
        " Width=\"96.39\"/>\r\n        <TableColumn Name=\"Column11\" Width=\"342.09\"/>\r\n       " +
        " <TableRow Name=\"Row7\" Height=\"75.6\">\r\n          <TableCell Name=\"Cell257\" Font=" +
        "\"宋体, 9pt\" RowSpan=\"6\">\r\n            <TextObject Name=\"Text29\" Width=\"68.04\" Heig" +
        "ht=\"264.6\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"产品要求\" HorzAlign=\"Center\" VertAli" +
        "gn=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Na" +
        "me=\"Cell258\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text16\" Width=\"96.39" +
        "\" Height=\"75.6\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"输入国\" HorzAlign=\"Center\" Ver";
      reportString += "tAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n          </TableCell>\r\n          <TableCell N" +
        "ame=\"Cell259\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text19\" Width=\"115." +
        "29\" Height=\"75.6\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP153]\" HorzAlign=" +
        "\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n       " +
        "   <TableCell Name=\"Cell260\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text" +
        "22\" Width=\"96.39\" Height=\"75.6\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"法规标准\" HorzA" +
        "lign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n  " +
        "        <TableCell Name=\"Cell261\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=" +
        "\"Text25\" Left=\"28.35\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"EN71\" VertAlig" +
        "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text77\" Left=\"94.5" +
        "\" Top=\"9.45\" Width=\"75.6\" Height=\"18.9\" Text=\"ASTM F963\" VertAlign=\"Center\" Font" +
        "=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text78\" Left=\"198.45\" Top=\"9.45\" ";
      reportString += "Width=\"56.7\" Height=\"18.9\" Text=\"ST2002\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r" +
        "\n            <TextObject Name=\"Text79\" Left=\"283.5\" Top=\"9.45\" Width=\"56.7\" Heig" +
        "ht=\"18.9\" Text=\"GB6675\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Che" +
        "ckBoxObject Name=\"CheckBox1\" Left=\"9.45\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" B" +
        "order.Lines=\"All\" Expression=\"IIf([R_PQM.CP007]==&quot;T&quot;,true,false)\"/>\r\n " +
        "           <CheckBoxObject Name=\"CheckBox2\" Left=\"75.6\" Top=\"9.45\" Width=\"18.9\" " +
        "Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP008]==&quot;T&quot;,tr" +
        "ue,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox3\" Left=\"179.55\" Top=\"9." +
        "45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP011]=" +
        "=&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox4\" Left" +
        "=\"264.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"II" +
        "f([R_PQM.CP012]==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=";
      reportString += "\"CheckBox10\" Left=\"9.45\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"Al" +
        "l\" Expression=\"IIf([R_PQM.CP014]==&quot;T&quot;,true,false)\"/>\r\n            <Tex" +
        "tObject Name=\"Text110\" Left=\"28.35\" Top=\"47.25\" Width=\"37.8\" Height=\"18.9\" Text=" +
        "\"全球\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text2" +
        "47\" Left=\"85.05\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R" +
        "_PQM.CP007]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text248\" Left=\"113." +
        "4\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP008]\" F" +
        "ont=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text249\" Left=\"141.75\" Top=\"47.25" +
        "\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP011]\" Font=\"宋体, 9pt\"" +
        "/>\r\n            <TextObject Name=\"Text250\" Left=\"170.1\" Top=\"47.25\" Width=\"18.9\"" +
        " Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP012]\" Font=\"宋体, 9pt\"/>\r\n          " +
        "  <TextObject Name=\"Text251\" Left=\"198.45\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9";
      reportString += "\" Visible=\"false\" Text=\"[R_PQM.CP014]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject" +
        " Name=\"Text252\" Left=\"226.8\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"fal" +
        "se\" Text=\"[R_PQM.CP015]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text253" +
        "\" Left=\"255.15\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_" +
        "PQM.CP016]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text254\" Left=\"283.5" +
        "\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP026]\" Fo" +
        "nt=\"宋体, 9pt\"/>\r\n          </TableCell>\r\n        </TableRow>\r\n        <TableRow N" +
        "ame=\"Row8\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell262\" Font=\"宋体, 9pt\"/>\r" +
        "\n          <TableCell Name=\"Cell263\" Font=\"宋体, 9pt\">\r\n            <TextObject Na" +
        "me=\"Text17\" Width=\"96.39\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"含水率" +
        "\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCe" +
        "ll>\r\n          <TableCell Name=\"Cell264\" Font=\"宋体, 9pt\">\r\n            <TextObjec";
      reportString += "t Name=\"Text20\" Width=\"115.29\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text" +
        "=\"[R_PQM.CP154]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n    " +
        "      </TableCell>\r\n          <TableCell Name=\"Cell265\" Font=\"宋体, 9pt\">\r\n       " +
        "     <TextObject Name=\"Text23\" Width=\"96.39\" Height=\"37.8\" Dock=\"Fill\" Border.Li" +
        "nes=\"All\" Text=\"年龄段\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n" +
        "          </TableCell>\r\n          <TableCell Name=\"Cell266\" Font=\"宋体, 9pt\">\r\n   " +
        "         <TextObject Name=\"Text26\" Width=\"342.09\" Height=\"37.8\" Dock=\"Fill\" Bord" +
        "er.Lines=\"All\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      " +
        "      <TextObject Name=\"Text80\" Left=\"28.35\" Top=\"9.45\" Width=\"37.8\" Height=\"18." +
        "9\" Text=\"18M-\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject N" +
        "ame=\"Text81\" Left=\"94.5\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"3Y-\" VertAl" +
        "ign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text82\" Left=\"19";
      reportString += "8.45\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"3Y+\" VertAlign=\"Center\" Font=\"" +
        "宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox5\" Left=\"9.45\" Top=\"9.4" +
        "5\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP015]==" +
        "&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox6\" Left=" +
        "\"75.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf(" +
        "[R_PQM.CP016]==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"C" +
        "heckBox7\" Left=\"179.55\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\"" +
        " Expression=\"IIf([R_PQM.CP026]==&quot;T&quot;,true,false)\"/>\r\n            <Check" +
        "BoxObject Name=\"CheckBox11\" Left=\"264.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" B" +
        "order.Lines=\"All\" Expression=\"IIf([R_PQM.CP027]!=&quot;&quot;,true,false)\"/>\r\n  " +
        "          <TextObject Name=\"Text241\" Left=\"283.5\" Top=\"9.45\" Width=\"56.7\" Height" +
        "=\"18.9\" Text=\"[R_PQM.CP027]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          <";
      reportString += "/TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row9\" Height=\"37.8\">\r\n" +
        "          <TableCell Name=\"Cell267\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=" +
        "\"Cell268\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text18\" Width=\"96.39\" H" +
        "eight=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"检测报告号\" HorzAlign=\"Center\" Vert" +
        "Align=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell" +
        " Name=\"Cell269\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text21\" Width=\"11" +
        "5.29\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP155]\" HorzAlig" +
        "n=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n     " +
        "     <TableCell Name=\"Cell270\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Te" +
        "xt24\" Width=\"96.39\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"AQL\" Horz" +
        "Align=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n " +
        "         <TableCell Name=\"Cell271\" Font=\"宋体, 9pt\">\r\n            <TextObject Name";
      reportString += "=\"Text27\" Width=\"342.09\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_P" +
        "QM.CP028]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          " +
        "</TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row10\" Height=\"37.8\">" +
        "\r\n          <TableCell Name=\"Cell272\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Nam" +
        "e=\"Cell273\" Font=\"宋体, 9pt\" ColSpan=\"4\" RowSpan=\"3\">\r\n            <TextObject Nam" +
        "e=\"Text28\" Width=\"650.16\" Height=\"113.4\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R" +
        "_PQM.CP029]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n        " +
        "  </TableCell>\r\n          <TableCell Name=\"Cell274\" Font=\"宋体, 9pt\"/>\r\n          " +
        "<TableCell Name=\"Cell275\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell276\" " +
        "Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row11\" Height=\"37" +
        ".8\">\r\n          <TableCell Name=\"Cell277\" Font=\"宋体, 9pt\"/>\r\n          <TableCell" +
        " Name=\"Cell278\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell279\" Font=\"宋体, ";
      reportString += "9pt\"/>\r\n          <TableCell Name=\"Cell280\" Font=\"宋体, 9pt\"/>\r\n          <TableCe" +
        "ll Name=\"Cell281\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=" +
        "\"Row12\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell282\" Font=\"宋体, 9pt\"/>\r\n  " +
        "        <TableCell Name=\"Cell283\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"C" +
        "ell284\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell285\" Font=\"宋体, 9pt\"/>\r\n" +
        "          <TableCell Name=\"Cell286\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n     " +
        "   <TableRow Name=\"Row13\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell287\" Fo" +
        "nt=\"宋体, 9pt\" RowSpan=\"3\">\r\n            <TextObject Name=\"Text30\" Width=\"68.04\" H" +
        "eight=\"113.4\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"产品功能描述\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCe" +
        "ll Name=\"Cell288\" Font=\"宋体, 9pt\" ColSpan=\"4\" RowSpan=\"3\">\r\n            <TextObje" +
        "ct Name=\"Text31\" Width=\"650.16\" Height=\"113.4\" Dock=\"Fill\" Border.Lines=\"All\" Ho";
      reportString += "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r" +
        "\n          <TableCell Name=\"Cell289\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name" +
        "=\"Cell290\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell291\" Font=\"宋体, 9pt\"/" +
        ">\r\n        </TableRow>\r\n        <TableRow Name=\"Row14\" Height=\"37.8\">\r\n         " +
        " <TableCell Name=\"Cell292\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell293\"" +
        " Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell294\" Font=\"宋体, 9pt\"/>\r\n       " +
        "   <TableCell Name=\"Cell295\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell29" +
        "6\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row15\" Height=" +
        "\"37.8\">\r\n          <TableCell Name=\"Cell297\" Font=\"宋体, 9pt\"/>\r\n          <TableC" +
        "ell Name=\"Cell298\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell299\" Font=\"宋" +
        "体, 9pt\"/>\r\n          <TableCell Name=\"Cell300\" Font=\"宋体, 9pt\"/>\r\n          <Tabl" +
        "eCell Name=\"Cell301\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n      </TableObject>";
      reportString += "\r\n      <TableObject Name=\"Table3\" Top=\"652.05\" Width=\"718.2\" Height=\"368.55\" Bo" +
        "rder.Lines=\"All\">\r\n        <TableColumn Name=\"Column12\" Width=\"39.69\"/>\r\n       " +
        " <TableColumn Name=\"Column13\" Width=\"77.49\"/>\r\n        <TableColumn Name=\"Column" +
        "14\" Width=\"181.44\"/>\r\n        <TableColumn Name=\"Column15\" Width=\"190.89\"/>\r\n   " +
        "     <TableColumn Name=\"Column16\" Width=\"228.69\"/>\r\n        <TableRow Name=\"Row1" +
        "6\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell302\" Font=\"宋体, 9pt\" RowSpan=\"9" +
        "\">\r\n            <TextObject Name=\"Text32\" Width=\"39.69\" Height=\"368.55\" Dock=\"Fi" +
        "ll\" Border.Lines=\"All\" Text=\"主&#13;&#10;要&#13;&#10;材&#13;&#10;料&#13;&#10;及&#13;&" +
        "#10;材&#13;&#10;质&#13;&#10;要&#13;&#10;求&#13;&#10;说&#13;&#10;明&#13;&#10;\" HorzAlig" +
        "n=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n     " +
        "     <TableCell Name=\"Cell303\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Te" +
        "xt33\" Width=\"77.49\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"材料类别\" Hor";
      reportString += "zAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n" +
        "          <TableCell Name=\"Cell304\" Font=\"宋体, 9pt\">\r\n            <TextObject Nam" +
        "e=\"Text34\" Width=\"181.44\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"使用位" +
        "置\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableC" +
        "ell>\r\n          <TableCell Name=\"Cell305\" Font=\"宋体, 9pt\">\r\n            <TextObje" +
        "ct Name=\"Text35\" Width=\"190.89\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Tex" +
        "t=\"质量等级\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </" +
        "TableCell>\r\n          <TableCell Name=\"Cell306\" Font=\"宋体, 9pt\">\r\n            <Te" +
        "xtObject Name=\"Text36\" Width=\"228.69\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"Al" +
        "l\" Text=\"工艺及特殊要求\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n   " +
        "       </TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row17\" Height=" +
        "\"37.8\">\r\n          <TableCell Name=\"Cell307\" Font=\"宋体, 9pt\"/>\r\n          <TableC";
      reportString += "ell Name=\"Cell308\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text37\" Width=" +
        "\"77.49\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"木(实木)\" HorzAlign=\"Cen" +
        "ter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <" +
        "TableCell Name=\"Cell309\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text45\" " +
        "Width=\"181.44\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP031]\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCel" +
        "l>\r\n          <TableCell Name=\"Cell310\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n    " +
        "        <CheckBoxObject Name=\"CheckBox8\" Left=\"9.45\" Top=\"9.45\" Width=\"18.9\" Hei" +
        "ght=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP032]==&quot;T&quot;,true," +
        "false)\"/>\r\n            <TextObject Name=\"Text83\" Left=\"28.35\" Top=\"9.45\" Width=\"" +
        "37.8\" Height=\"18.9\" Text=\"清水\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          " +
        "  <CheckBoxObject Name=\"CheckBox9\" Left=\"94.5\" Top=\"9.45\" Width=\"18.9\" Height=\"1";
      reportString += "8.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP160]==&quot;T&quot;,true,false)" +
        "\"/>\r\n            <TextObject Name=\"Text84\" Left=\"113.4\" Top=\"9.45\" Width=\"37.8\" " +
        "Height=\"18.9\" Text=\"浑水\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Tex" +
        "tObject Name=\"Text255\" Left=\"66.15\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visibl" +
        "e=\"false\" Text=\"[R_PQM.CP032]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"T" +
        "ext256\" Left=\"151.2\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=" +
        "\"[R_PQM.CP160]\" Font=\"宋体, 9pt\"/>\r\n          </TableCell>\r\n          <TableCell N" +
        "ame=\"Cell311\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"" +
        "Text86\" Width=\"228.69\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM" +
        ".CP033]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </" +
        "TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row18\" Height=\"37.8\">\r\n" +
        "          <TableCell Name=\"Cell312\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=";
      reportString += "\"Cell313\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text38\" Width=\"77.49\" H" +
        "eight=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"夹板\" HorzAlign=\"Center\" VertAli" +
        "gn=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Na" +
        "me=\"Cell314\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text46\" Width=\"181.4" +
        "4\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP035]\" HorzAlign=\"" +
        "Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        " +
        "  <TableCell Name=\"Cell315\" Border.Lines=\"All\" Font=\"宋体, 9pt\" RowSpan=\"2\">\r\n    " +
        "        <CheckBoxObject Name=\"CheckBox12\" Left=\"9.45\" Top=\"9.45\" Width=\"18.9\" He" +
        "ight=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP036]==&quot;T&quot;,true" +
        ",false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox13\" Left=\"9.45\" Top=\"47.25" +
        "\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP161]==&" +
        "quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text85\" Left=\"28.35\" ";
      reportString += "Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" Text=\"E0\" VertAlign=\"Center\" Font=\"宋体, 10" +
        ".5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox15\" Left=\"94.5\" Top=\"9.45\" Wi" +
        "dth=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP040]==&quot" +
        ";T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text90\" Left=\"113.4\" Top=" +
        "\"9.45\" Width=\"28.35\" Height=\"18.9\" Text=\"E1\" VertAlign=\"Center\" Font=\"宋体, 10.5pt" +
        "\"/>\r\n            <TextObject Name=\"Text91\" Left=\"28.35\" Top=\"47.25\" Width=\"37.8\"" +
        " Height=\"18.9\" Text=\"CARB\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <" +
        "CheckBoxObject Name=\"CheckBox17\" Left=\"94.5\" Top=\"47.25\" Width=\"18.9\" Height=\"18" +
        ".9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP162]==&quot;T&quot;,true,false)\"" +
        "/>\r\n            <TextObject Name=\"Text92\" Left=\"113.4\" Top=\"47.25\" Width=\"37.8\" " +
        "Height=\"18.9\" Text=\"FSC\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Te" +
        "xtObject Name=\"Text257\" Left=\"56.7\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visibl";
      reportString += "e=\"false\" Text=\"[R_PQM.CP036]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"T" +
        "ext258\" Left=\"141.75\" Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" Visible=\"false\" Tex" +
        "t=\"[R_PQM.CP040]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text259\" Left=" +
        "\"66.15\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP16" +
        "1]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text260\" Left=\"151.2\" Top=\"4" +
        "7.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP162]\" Font=\"宋体, " +
        "9pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell316\" Border.Lines" +
        "=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text87\" Width=\"228.69\" Hei" +
        "ght=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP037]\" HorzAlign=\"Center" +
        "\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        </Tabl" +
        "eRow>\r\n        <TableRow Name=\"Row19\" Height=\"37.8\">\r\n          <TableCell Name=" +
        "\"Cell317\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell318\" Font=\"宋体, 9pt\">\r";
      reportString += "\n            <TextObject Name=\"Text39\" Width=\"77.49\" Height=\"37.8\" Dock=\"Fill\" B" +
        "order.Lines=\"All\" Text=\"MDF\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10." +
        "5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell319\" Font=\"宋体, 9p" +
        "t\">\r\n            <TextObject Name=\"Text47\" Width=\"181.44\" Height=\"37.8\" Dock=\"Fi" +
        "ll\" Border.Lines=\"All\" Text=\"[R_PQM.CP039]\" HorzAlign=\"Center\" VertAlign=\"Center" +
        "\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell32" +
        "0\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell321\" Border.Lines=\"All\" Font" +
        "=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text88\" Width=\"228.69\" Height=\"37.8\" " +
        "Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP041]\" HorzAlign=\"Center\" VertAlign" +
        "=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        </TableRow>\r\n    " +
        "    <TableRow Name=\"Row20\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell322\" F" +
        "ont=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell323\" Font=\"宋体, 9pt\">\r\n          ";
      reportString += "  <TextObject Name=\"Text40\" Width=\"77.49\" Height=\"37.8\" Dock=\"Fill\" Border.Lines" +
        "=\"All\" Text=\"漆\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n     " +
        "     </TableCell>\r\n          <TableCell Name=\"Cell324\" Font=\"宋体, 9pt\">\r\n        " +
        "    <TextObject Name=\"Text48\" Width=\"181.44\" Height=\"37.8\" Dock=\"Fill\" Border.Li" +
        "nes=\"All\" Text=\"[R_PQM.CP043]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 1" +
        "0.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell325\" Border.Lin" +
        "es=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text89\" Width=\"190.89\" H" +
        "eight=\"37.8\" Dock=\"Fill\" Text=\"[R_PQM.CP044]\" HorzAlign=\"Center\" VertAlign=\"Cent" +
        "er\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell" +
        "326\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text94\" L" +
        "eft=\"151.2\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"水性\" VertAlign=\"Center\" F" +
        "ont=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox19\" Left=\"132.3\" T";
      reportString += "op=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.C" +
        "P163]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text93\" Left=" +
        "\"47.25\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"油性\" VertAlign=\"Center\" Font=" +
        "\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox18\" Left=\"28.35\" Top=\"" +
        "9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP045" +
        "]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text261\" Left=\"85" +
        ".05\" Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP045]\"" +
        " Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text262\" Left=\"189\" Top=\"9.45\" " +
        "Width=\"28.35\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP163]\" Font=\"宋体, 9pt\"/" +
        ">\r\n          </TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row21\" H" +
        "eight=\"66.15\">\r\n          <TableCell Name=\"Cell327\" Font=\"宋体, 9pt\"/>\r\n          " +
        "<TableCell Name=\"Cell328\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text41\"";
      reportString += " Width=\"77.49\" Height=\"66.15\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"油墨\" HorzAlign" +
        "=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n      " +
        "    <TableCell Name=\"Cell329\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Tex" +
        "t49\" Width=\"181.44\" Height=\"66.15\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.C" +
        "P047]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </Ta" +
        "bleCell>\r\n          <TableCell Name=\"Cell330\" Border.Lines=\"All\" Font=\"宋体, 9pt\">" +
        "\r\n            <TextObject Name=\"Text99\" Width=\"190.89\" Height=\"66.15\" Dock=\"Fill" +
        "\" Text=\"[R_PQM.CP048]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>" +
        "\r\n          </TableCell>\r\n          <TableCell Name=\"Cell331\" Border.Lines=\"All\"" +
        " Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text97\" Left=\"151.2\" Top=\"9.45\" " +
        "Width=\"56.7\" Height=\"18.9\" Text=\"热转印\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n  " +
        "          <CheckBoxObject Name=\"CheckBox22\" Left=\"132.3\" Top=\"9.45\" Width=\"18.9\"";
      reportString += " Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP164]==&quot;T&quot;,t" +
        "rue,false)\"/>\r\n            <TextObject Name=\"Text95\" Left=\"47.25\" Top=\"9.45\" Wid" +
        "th=\"37.8\" Height=\"18.9\" Text=\"丝网\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      " +
        "      <CheckBoxObject Name=\"CheckBox20\" Left=\"28.35\" Top=\"9.45\" Width=\"18.9\" Hei" +
        "ght=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP049]==&quot;T&quot;,true," +
        "false)\"/>\r\n            <TextObject Name=\"Text98\" Left=\"151.2\" Top=\"37.8\" Width=\"" +
        "37.8\" Height=\"18.9\" Text=\"手绘\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          " +
        "  <CheckBoxObject Name=\"CheckBox23\" Left=\"132.3\" Top=\"37.8\" Width=\"18.9\" Height=" +
        "\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP173]==&quot;T&quot;,true,fals" +
        "e)\"/>\r\n            <TextObject Name=\"Text96\" Left=\"47.25\" Top=\"37.8\" Width=\"37.8" +
        "\" Height=\"18.9\" Text=\"移印\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <C" +
        "heckBoxObject Name=\"CheckBox21\" Left=\"28.35\" Top=\"37.8\" Width=\"18.9\" Height=\"18.";
      reportString += "9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP165]==&quot;T&quot;,true,false)\"/" +
        ">\r\n            <TextObject Name=\"Text263\" Left=\"85.05\" Top=\"9.45\" Width=\"18.9\" H" +
        "eight=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP049]\" Font=\"宋体, 9pt\"/>\r\n            " +
        "<TextObject Name=\"Text264\" Left=\"207.9\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Vi" +
        "sible=\"false\" Text=\"[R_PQM.CP164]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Nam" +
        "e=\"Text265\" Left=\"85.05\" Top=\"37.8\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" T" +
        "ext=\"[R_PQM.CP165]\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text266\" Lef" +
        "t=\"198.45\" Top=\"37.8\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP" +
        "173]\" Font=\"宋体, 9pt\"/>\r\n          </TableCell>\r\n        </TableRow>\r\n        <Ta" +
        "bleRow Name=\"Row22\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell332\" Font=\"宋体" +
        ", 9pt\"/>\r\n          <TableCell Name=\"Cell333\" Font=\"宋体, 9pt\">\r\n            <Text" +
        "Object Name=\"Text42\" Width=\"77.49\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" ";
      reportString += "Text=\"塑料\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          <" +
        "/TableCell>\r\n          <TableCell Name=\"Cell334\" Font=\"宋体, 9pt\">\r\n            <T" +
        "extObject Name=\"Text50\" Width=\"181.44\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"A" +
        "ll\" Text=\"[R_PQM.CP051]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"" +
        "/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell335\" Border.Lines=\"Al" +
        "l\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text100\" Width=\"190.89\" Height" +
        "=\"37.8\" Dock=\"Fill\" Text=\"[R_PQM.CP052]\" HorzAlign=\"Center\" VertAlign=\"Center\" F" +
        "ont=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell336\" " +
        "Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text104\" Left=" +
        "\"179.55\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"吹塑\" VertAlign=\"Center\" Font" +
        "=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox29\" Left=\"160.65\" Top" +
        "=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP1";
      reportString += "74]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text103\" Left=\"" +
        "103.95\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"注塑\" VertAlign=\"Center\" Font=" +
        "\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox28\" Left=\"85.05\" Top=\"" +
        "9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP175" +
        "]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text102\" Left=\"28" +
        ".35\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"吸塑\" VertAlign=\"Center\" Font=\"宋体" +
        ", 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox27\" Left=\"9.45\" Top=\"9.45" +
        "\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP153]==&" +
        "quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text267\" Left=\"217.35" +
        "\" Top=\"9.45\" Width=\"9.45\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP174]\" Fon" +
        "t=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text268\" Left=\"141.75\" Top=\"9.45\" W" +
        "idth=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP175]\" Font=\"宋体, 9pt\"/>\r";
      reportString += "\n            <TextObject Name=\"Text269\" Left=\"66.15\" Top=\"9.45\" Width=\"18.9\" Hei" +
        "ght=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP153]\" Font=\"宋体, 9pt\"/>\r\n          </Ta" +
        "bleCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row23\" Height=\"37.8\">\r\n  " +
        "        <TableCell Name=\"Cell337\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"C" +
        "ell338\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text43\" Width=\"77.49\" Hei" +
        "ght=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"五金\" HorzAlign=\"Center\" VertAlign" +
        "=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name" +
        "=\"Cell339\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text51\" Width=\"181.44\"" +
        " Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP055]\" HorzAlign=\"Ce" +
        "nter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          " +
        "<TableCell Name=\"Cell340\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextO" +
        "bject Name=\"Text101\" Width=\"190.89\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\"";
      reportString += " Text=\"[R_PQM.CP056]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r" +
        "\n          </TableCell>\r\n          <TableCell Name=\"Cell341\" Border.Lines=\"All\" " +
        "Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text108\" Left=\"56.7\" Top=\"9.45\" W" +
        "idth=\"160.65\" Height=\"18.9\" Text=\"[R_PQM.CP057]\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text107\" Top=\"9.45\" Wi" +
        "dth=\"56.7\" Height=\"18.9\" Text=\"镀层：\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n    " +
        "      </TableCell>\r\n        </TableRow>\r\n        <TableRow Name=\"Row24\" Height=\"" +
        "37.8\">\r\n          <TableCell Name=\"Cell342\" Font=\"宋体, 9pt\"/>\r\n          <TableCe" +
        "ll Name=\"Cell343\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text44\" Width=\"" +
        "77.49\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"绳或布类\" HorzAlign=\"Cente" +
        "r\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <Ta" +
        "bleCell Name=\"Cell344\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text52\" Wi";
      reportString += "dth=\"181.44\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP059]\" H" +
        "orzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>" +
        "\r\n          <TableCell Name=\"Cell345\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n      " +
        "      <TextObject Name=\"Text105\" Width=\"190.89\" Height=\"37.8\" Dock=\"Fill\" Border" +
        ".Lines=\"All\" Text=\"[R_PQM.CP060]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体" +
        ", 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell346\" Border." +
        "Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text106\" Width=\"228.6" +
        "9\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"[R_PQM.CP061]\" HorzAlign=\"" +
        "Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        " +
        "</TableRow>\r\n      </TableObject>\r\n      <TableObject Name=\"Table6\" Top=\"1020.6\"" +
        " Width=\"718.2\" Height=\"37.8\" Border.Lines=\"All\">\r\n        <TableColumn Name=\"Col" +
        "umn29\" Width=\"179.55\"/>\r\n        <TableColumn Name=\"Column30\" Width=\"179.55\"/>\r\n";
      reportString += "        <TableColumn Name=\"Column31\" Width=\"179.55\"/>\r\n        <TableColumn Name" +
        "=\"Column32\" Width=\"179.55\"/>\r\n        <TableRow Name=\"Row49\" Height=\"37.8\">\r\n   " +
        "       <TableCell Name=\"Cell472\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"" +
        "Text242\" Width=\"179.55\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"材料名称\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCel" +
        "l>\r\n          <TableCell Name=\"Cell473\" Font=\"宋体, 9pt\">\r\n            <TextObject" +
        " Name=\"Text243\" Width=\"179.55\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text" +
        "=\"规格\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </Tab" +
        "leCell>\r\n          <TableCell Name=\"Cell474\" Font=\"宋体, 9pt\">\r\n            <TextO" +
        "bject Name=\"Text244\" Width=\"179.55\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\"" +
        " Text=\"每套材料用量\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      " +
        "    </TableCell>\r\n          <TableCell Name=\"Cell475\" Font=\"宋体, 9pt\">\r\n         ";
      reportString += "   <TextObject Name=\"Text245\" Width=\"179.55\" Height=\"37.8\" Dock=\"Fill\" Border.Li" +
        "nes=\"All\" Text=\"客供状态\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r" +
        "\n          </TableCell>\r\n        </TableRow>\r\n      </TableObject>\r\n    </Report" +
        "TitleBand>\r\n    <DataBand Name=\"Data1\" Top=\"1061.73\" Width=\"718.2\" Height=\"37.8\"" +
        " CanBreak=\"true\" Guides=\"37.8,28.35,28.35,18.9,18.9,37.8,28.35,18.9,28.35,18.9,2" +
        "8.35,18.9,28.35,28.35,18.9,18.9,18.9,18.9,18.9,37.8,37.8,37.8,18.9,18.9,0,0,28.3" +
        "5\">\r\n      <TableObject Name=\"Table7\" Width=\"718.2\" Height=\"37.8\" Border.Lines=\"" +
        "All\">\r\n        <TableColumn Name=\"Column33\" Width=\"179.55\"/>\r\n        <TableColu" +
        "mn Name=\"Column34\" Width=\"179.55\"/>\r\n        <TableColumn Name=\"Column35\" Width=" +
        "\"179.55\"/>\r\n        <TableColumn Name=\"Column36\" Width=\"179.55\"/>\r\n        <Tabl" +
        "eRow Name=\"Row50\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell476\" Border.Lin" +
        "es=\"All\" Text=\"[R_PQMS.CP156]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9";
      reportString += "pt\"/>\r\n          <TableCell Name=\"Cell477\" Border.Lines=\"All\" Text=\"[R_PQMS.CP15" +
        "7]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n          <TableCell" +
        " Name=\"Cell478\" Border.Lines=\"All\" Text=\"[R_PQMS.CP158]\" HorzAlign=\"Center\" Vert" +
        "Align=\"Center\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell479\" Border.Line" +
        "s=\"All\" Text=\"[R_PQMS.CP159]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9p" +
        "t\"/>\r\n        </TableRow>\r\n      </TableObject>\r\n    </DataBand>\r\n    <ReportSum" +
        "maryBand Name=\"ReportSummary1\" Top=\"1102.87\" Width=\"718.2\" Height=\"1493.1\" CanBr" +
        "eak=\"true\">\r\n      <TableObject Name=\"Table5\" Top=\"765.45\" Width=\"718.2\" Height=" +
        "\"500.85\" Border.Lines=\"All\">\r\n        <TableColumn Name=\"Column20\" Width=\"78.75\"" +
        "/>\r\n        <TableColumn Name=\"Column21\" Width=\"192.15\"/>\r\n        <TableColumn " +
        "Name=\"Column22\" Width=\"447.3\"/>\r\n        <TableRow Name=\"Row33\" Height=\"189\">\r\n " +
        "         <TableCell Name=\"Cell381\" Font=\"宋体, 9pt\">\r\n            <TextObject Name";
      reportString += "=\"Text64\" Width=\"78.75\" Height=\"189\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"唛头\" Ho" +
        "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r" +
        "\n          <TableCell Name=\"Cell382\" Font=\"宋体, 9pt\" ColSpan=\"2\">\r\n            <P" +
        "ictureObject Name=\"Picture5\" Top=\"28.35\" Width=\"207.9\" Height=\"158.76\" SizeMode=" +
        "\"StretchImage\" DataColumn=\"R_PQM.CP148\"/>\r\n            <PictureObject Name=\"Pict" +
        "ure6\" Left=\"207.9\" Top=\"28.35\" Width=\"207.9\" Height=\"158.76\" SizeMode=\"StretchIm" +
        "age\" DataColumn=\"R_PQM.CP149\"/>\r\n            <PictureObject Name=\"Picture7\" Left" +
        "=\"415.8\" Top=\"28.35\" Width=\"215.46\" Height=\"158.76\" SizeMode=\"StretchImage\" Data" +
        "Column=\"R_PQM.CP150\"/>\r\n            <TextObject Name=\"Text65\" Width=\"56.7\" Heigh" +
        "t=\"28.35\" Text=\"正唛\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <TextObject Name=\"Text66\" Left=\"207.9\" Width=\"56.7\" Height=\"28.35\" Te" +
        "xt=\"侧唛\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <";
      reportString += "TextObject Name=\"Text246\" Left=\"415.8\" Width=\"47.25\" Height=\"28.35\" Text=\"彩盒\" Ho" +
        "rzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r" +
        "\n          <TableCell Name=\"Cell383\" Border.Lines=\"Bottom\" Font=\"宋体, 9pt\"/>\r\n   " +
        "     </TableRow>\r\n        <TableRow Name=\"Row34\" Height=\"122.85\">\r\n          <Ta" +
        "bleCell Name=\"Cell386\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text67\" Wi" +
        "dth=\"78.75\" Height=\"122.85\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"条形码\" HorzAlign=" +
        "\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n       " +
        "   <TableCell Name=\"Cell387\" Font=\"宋体, 9pt\" ColSpan=\"2\">\r\n            <PictureOb" +
        "ject Name=\"Picture8\" Width=\"639.45\" Height=\"122.85\" Dock=\"Fill\" Border.Lines=\"Al" +
        "l\" SizeMode=\"StretchImage\" DataColumn=\"R_PQM.CP151\"/>\r\n          </TableCell>\r\n " +
        "         <TableCell Name=\"Cell388\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n      " +
        "  <TableRow Name=\"Row35\" Height=\"189\">\r\n          <TableCell Name=\"Cell391\" Font";
      reportString += "=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text69\" Width=\"78.75\" Height=\"189\" Do" +
        "ck=\"Fill\" Border.Lines=\"All\" Text=\"客&#13;&#10;户&#13;&#10;反&#13;&#10;馈\" HorzAlign" +
        "=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n      " +
        "    <TableCell Name=\"Cell392\" Font=\"宋体, 9pt\" ColSpan=\"2\">\r\n            <TextObje" +
        "ct Name=\"Text68\" Width=\"639.45\" Height=\"189\" Dock=\"Fill\" Border.Lines=\"All\" Text" +
        "=\"[R_PQM.CP152]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n    " +
        "      </TableCell>\r\n          <TableCell Name=\"Cell393\" Font=\"宋体, 9pt\"/>\r\n      " +
        "  </TableRow>\r\n      </TableObject>\r\n      <TextObject Name=\"Text73\" Left=\"9.45\"" +
        " Top=\"1323\" Width=\"132.3\" Height=\"28.35\" Text=\"2、技术图纸及彩稿\" VertAlign=\"Center\" Fon" +
        "t=\"宋体, 10.5pt\"/>\r\n      <TextObject Name=\"Text74\" Left=\"9.45\" Top=\"1351.35\" Widt" +
        "h=\"132.3\" Height=\"28.35\" Text=\"3、第三方检测报告\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>" +
        "\r\n      <TextObject Name=\"Text75\" Left=\"9.45\" Top=\"1379.7\" Width=\"207.9\" Height=";
      reportString += "\"28.35\" Text=\"4、厂内质检部出具的检验报告\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      <Tex" +
        "tObject Name=\"Text76\" Left=\"9.45\" Top=\"1408.05\" Width=\"189\" Height=\"28.35\" Text=" +
        "\"5、预算报价单和成本汇总表\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      <TextObject Name=\"" +
        "Text72\" Left=\"9.45\" Top=\"1294.65\" Width=\"122.85\" Height=\"28.35\" Text=\"1、销售合同正本\" " +
        "VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      <TableObject Name=\"Table4\" Width=\"" +
        "718.2\" Height=\"765.45\" Border.Lines=\"All\">\r\n        <TableColumn Name=\"Column23\"" +
        " Width=\"29.92\"/>\r\n        <TableColumn Name=\"Column24\" Width=\"86.63\"/>\r\n        " +
        "<TableColumn Name=\"Column25\" Width=\"124.43\"/>\r\n        <TableColumn Name=\"Column" +
        "26\" Width=\"143.32\"/>\r\n        <TableColumn Name=\"Column27\" Width=\"133.88\"/>\r\n   " +
        "     <TableColumn Name=\"Column28\" Width=\"200.02\"/>\r\n        <TableRow Name=\"Row3" +
        "6\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell394\" Font=\"宋体, 9pt\" RowSpan=\"1" +
        "3\">\r\n            <TextObject Name=\"Text109\" Width=\"29.92\" Height=\"765.45\" Dock=\"";
      reportString += "Fill\" Border.Lines=\"All\" Text=\"包&#13;&#10;&#13;&#10;装&#13;&#10;&#13;&#10;要&#13;&" +
        "#10;&#13;&#10;求\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r" +
        "\n          <TableCell Name=\"Cell395\" Font=\"宋体, 9pt\" RowSpan=\"3\">\r\n            <T" +
        "extObject Name=\"Text53\" Width=\"86.63\" Height=\"113.4\" Dock=\"Fill\" Border.Lines=\"A" +
        "ll\" Text=\"包装方式\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n     " +
        "     </TableCell>\r\n          <TableCell Name=\"Cell396\" Font=\"宋体, 9pt\" ColSpan=\"4" +
        "\" RowSpan=\"2\">\r\n            <TextObject Name=\"Text54\" Width=\"601.65\" Height=\"75." +
        "6\" Dock=\"Fill\" Border.Lines=\"All\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体" +
        ", 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox34\" Left=\"9.45\" Top=\"9.45" +
        "\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP062]==&" +
        "quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text55\" Left=\"28.35\" " +
        "Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"白盒\" HorzAlign=\"Center\" VertAlign=\"Ce";
      reportString += "nter\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox35\" Left=\"7" +
        "5.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R" +
        "_PQM.CP063]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text56\"" +
        " Left=\"94.5\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"彩盒\" HorzAlign=\"Center\" " +
        "VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckB" +
        "ox36\" Left=\"141.75\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Exp" +
        "ression=\"IIf([R_PQM.CP064]==&quot;T&quot;,true,false)\"/>\r\n            <TextObjec" +
        "t Name=\"Text57\" Left=\"160.65\" Top=\"9.45\" Width=\"56.7\" Height=\"18.9\" Text=\"气泡袋\" H" +
        "orzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxO" +
        "bject Name=\"CheckBox37\" Left=\"226.8\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Borde" +
        "r.Lines=\"All\" Expression=\"IIf([R_PQM.CP065]==&quot;T&quot;,true,false)\"/>\r\n     " +
        "       <TextObject Name=\"Text58\" Left=\"245.7\" Top=\"9.45\" Width=\"56.7\" Height=\"18";
      reportString += ".9\" Text=\"珍珠棉\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n      " +
        "      <CheckBoxObject Name=\"CheckBox38\" Left=\"311.85\" Top=\"9.45\" Width=\"18.9\" He" +
        "ight=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP066]==&quot;T&quot;,true" +
        ",false)\"/>\r\n            <TextObject Name=\"Text59\" Left=\"330.75\" Top=\"9.45\" Width" +
        "=\"56.7\" Height=\"18.9\" Text=\"自封袋\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体," +
        " 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox39\" Left=\"396.9\" Top=\"9.45" +
        "\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP067]==&" +
        "quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text60\" Left=\"415.8\" " +
        "Top=\"9.45\" Width=\"56.7\" Height=\"18.9\" Text=\"塑料袋\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox40\" Left=\"" +
        "481.95\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf" +
        "([R_PQM.CP068]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text";
      reportString += "61\" Left=\"500.85\" Top=\"9.45\" Width=\"56.7\" Height=\"18.9\" Text=\"吸塑袋\" HorzAlign=\"Ce" +
        "nter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"" +
        "CheckBox41\" Left=\"9.45\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All" +
        "\" Expression=\"IIf([R_PQM.CP069]==&quot;T&quot;,true,false)\"/>\r\n            <Text" +
        "Object Name=\"Text62\" Left=\"28.35\" Top=\"47.25\" Width=\"37.8\" Height=\"18.9\" Text=\"布" +
        "袋\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Check" +
        "BoxObject Name=\"CheckBox42\" Left=\"75.6\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" B" +
        "order.Lines=\"All\" Expression=\"IIf([R_PQM.CP070]==&quot;T&quot;,true,false)\"/>\r\n " +
        "           <TextObject Name=\"Text63\" Left=\"94.5\" Top=\"47.25\" Width=\"37.8\" Height" +
        "=\"18.9\" Text=\"棕盒\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n   " +
        "         <CheckBoxObject Name=\"CheckBox43\" Left=\"141.75\" Top=\"47.25\" Width=\"18.9" +
        "\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP071]==&quot;T&quot;,";
      reportString += "true,false)\"/>\r\n            <TextObject Name=\"Text70\" Left=\"160.65\" Top=\"47.25\" " +
        "Width=\"56.7\" Height=\"18.9\" Text=\"天地盖\" HorzAlign=\"Center\" VertAlign=\"Center\" Font" +
        "=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text111\" Left=\"217.35\" Top=\"47.25" +
        "\" Width=\"47.25\" Height=\"18.9\" Text=\"[R_PQM.CP072]\" HorzAlign=\"Center\" VertAlign=" +
        "\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text112\" Left=\"264.6" +
        "\" Top=\"47.25\" Width=\"47.25\" Height=\"18.9\" Text=\"套/只\" HorzAlign=\"Center\" VertAlig" +
        "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text270\" Left=\"321" +
        ".3\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP062]\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject " +
        "Name=\"Text271\" Left=\"340.2\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"fals" +
        "e\" Text=\"[R_PQM.CP063]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n" +
        "            <TextObject Name=\"Text272\" Left=\"359.1\" Top=\"47.25\" Width=\"18.9\" Hei";
      reportString += "ght=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP064]\" HorzAlign=\"Center\" VertAlign=\"Ce" +
        "nter\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text273\" Left=\"378\" Top=\"4" +
        "7.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP065]\" HorzAlign=" +
        "\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text" +
        "274\" Left=\"396.9\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[" +
        "R_PQM.CP066]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n          " +
        "  <TextObject Name=\"Text275\" Left=\"415.8\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\"" +
        " Visible=\"false\" Text=\"[R_PQM.CP067]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font" +
        "=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text276\" Left=\"434.7\" Top=\"47.25\" Wi" +
        "dth=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP068]\" HorzAlign=\"Center\"" +
        " VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text277\" Lef" +
        "t=\"453.6\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP";
      reportString += "069]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextO" +
        "bject Name=\"Text278\" Left=\"472.5\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Visible" +
        "=\"false\" Text=\"[R_PQM.CP070]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9p" +
        "t\"/>\r\n            <TextObject Name=\"Text279\" Left=\"491.4\" Top=\"47.25\" Width=\"18." +
        "9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP071]\" HorzAlign=\"Center\" VertAli" +
        "gn=\"Center\" Font=\"宋体, 9pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=" +
        "\"Cell397\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell398\" Font=\"宋体, 9pt\"/>" +
        "\r\n          <TableCell Name=\"Cell459\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n   " +
        "     <TableRow Name=\"Row37\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell399\" " +
        "Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell400\" Font=\"宋体, 9pt\"/>\r\n        " +
        "  <TableCell Name=\"Cell401\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell402" +
        "\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell403\" Font=\"宋体, 9pt\"/>\r\n      ";
      reportString += "    <TableCell Name=\"Cell460\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <Ta" +
        "bleRow Name=\"Row38\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell404\" Font=\"宋体" +
        ", 9pt\"/>\r\n          <TableCell Name=\"Cell405\" Font=\"宋体, 9pt\"/>\r\n          <Table" +
        "Cell Name=\"Cell406\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject " +
        "Name=\"Text113\" Width=\"124.43\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=" +
        "\"中包\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </Tabl" +
        "eCell>\r\n          <TableCell Name=\"Cell407\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n" +
        "            <TextObject Name=\"Text114\" Top=\"9.45\" Width=\"85.05\" Height=\"18.9\" Te" +
        "xt=\"[R_PQM.CP073]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n  " +
        "          <TextObject Name=\"Text115\" Left=\"85.05\" Top=\"9.45\" Width=\"56.7\" Height" +
        "=\"18.9\" Text=\"套/包\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n  " +
        "        </TableCell>\r\n          <TableCell Name=\"Cell408\" Border.Lines=\"All\" Fon";
      reportString += "t=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text116\" Width=\"133.88\" Height=\"37.8" +
        "\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"大箱\" HorzAlign=\"Center\" VertAlign=\"Center\"" +
        " Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell461" +
        "\" Border.Lines=\"All\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text117\" Top" +
        "=\"9.45\" Width=\"103.95\" Height=\"18.9\" Text=\"[R_PQM.CP074]\" HorzAlign=\"Center\" Ver" +
        "tAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text118\" Left" +
        "=\"103.95\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"套/箱\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n        </TableRow" +
        ">\r\n        <TableRow Name=\"Row39\" Height=\"37.8\">\r\n          <TableCell Name=\"Cel" +
        "l409\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell410\" Font=\"宋体, 9pt\" RowSp" +
        "an=\"5\">\r\n            <TextObject Name=\"Text119\" Width=\"86.63\" Height=\"264.6\" Doc" +
        "k=\"Fill\" Border.Lines=\"All\" Text=\"标签种类及张贴位置\" HorzAlign=\"Center\" VertAlign=\"Cente";
      reportString += "r\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell4" +
        "11\" Border.Lines=\"All\" Font=\"宋体, 9pt\" ColSpan=\"4\" RowSpan=\"5\">\r\n            <Che" +
        "ckBoxObject Name=\"CheckBox44\" Left=\"9.45\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" " +
        "Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP075]!=&quot;&quot;,true,false)\"/>\r\n " +
        "           <TextObject Name=\"Text120\" Left=\"28.35\" Top=\"9.45\" Width=\"56.7\" Heigh" +
        "t=\"18.9\" Text=\"条形码\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <CheckBoxObject Name=\"CheckBox45\" Left=\"283.5\" Top=\"37.8\" Width=\"18.9" +
        "\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP092]!=&quot;&quot;,t" +
        "rue,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox46\" Left=\"9.45\" Top=\"66" +
        ".15\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP086]" +
        "!=&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text122\" Left=\"28.3" +
        "5\" Top=\"66.15\" Width=\"56.7\" Height=\"18.9\" Text=\"圆形标\" HorzAlign=\"Center\" VertAlig";
      reportString += "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox47\" Le" +
        "ft=\"283.5\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"" +
        "IIf([R_PQM.CP084]!=&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Te" +
        "xt123\" Left=\"302.4\" Top=\"9.45\" Width=\"103.95\" Height=\"18.9\" Text=\"made in china\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBo" +
        "xObject Name=\"CheckBox48\" Left=\"9.45\" Top=\"94.5\" Width=\"18.9\" Height=\"18.9\" Bord" +
        "er.Lines=\"All\" Expression=\"IIf([R_PQM.CP080]!=&quot;&quot;,true,false)\"/>\r\n     " +
        "       <TextObject Name=\"Text124\" Left=\"302.4\" Top=\"94.5\" Width=\"75.6\" Height=\"1" +
        "8.9\" Text=\"价格标签\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n    " +
        "        <CheckBoxObject Name=\"CheckBox49\" Left=\"283.5\" Top=\"66.15\" Width=\"18.9\" " +
        "Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP094]!=&quot;&quot;,tru" +
        "e,false)\"/>\r\n            <TextObject Name=\"Text125\" Left=\"302.4\" Top=\"66.15\" Wid";
      reportString += "th=\"56.7\" Height=\"18.9\" Text=\"防伪标\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋" +
        "体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox50\" Left=\"9.45\" Top=\"37." +
        "8\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP078]!=" +
        "&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text126\" Left=\"302.4\"" +
        " Top=\"37.8\" Width=\"75.6\" Height=\"18.9\" Text=\"批次标签\" HorzAlign=\"Center\" VertAlign=" +
        "\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text207\" Left=\"85.05" +
        "\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP075]\" HorzAlign=\"Center\" " +
        "VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text208\" L" +
        "eft=\"179.55\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP076]\" HorzAlig" +
        "n=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=" +
        "\"Text209\" Left=\"406.35\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP084" +
        "]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextO";
      reportString += "bject Name=\"Text210\" Left=\"500.85\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[" +
        "R_PQM.CP085]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n       " +
        "     <TextObject Name=\"Text121\" Left=\"28.35\" Top=\"37.8\" Width=\"28.35\" Height=\"18" +
        ".9\" Text=\"CE\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n       " +
        "     <TextObject Name=\"Text127\" Left=\"85.05\" Top=\"37.8\" Width=\"94.5\" Height=\"18." +
        "9\" Text=\"[R_PQM.CP078]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/" +
        ">\r\n            <TextObject Name=\"Text128\" Left=\"179.55\" Top=\"37.8\" Width=\"94.5\" " +
        "Height=\"18.9\" Text=\"[R_PQM.CP079]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋" +
        "体, 10.5pt\"/>\r\n            <TextObject Name=\"Text129\" Left=\"406.35\" Top=\"37.8\" Wi" +
        "dth=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP092]\" HorzAlign=\"Center\" VertAlign=\"Cent" +
        "er\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text130\" Left=\"500.85\" To" +
        "p=\"37.8\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP093]\" HorzAlign=\"Center\" Vert";
      reportString += "Align=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text131\" Left=" +
        "\"85.05\" Top=\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP086]\" HorzAlign=\"C" +
        "enter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Tex" +
        "t132\" Left=\"179.55\" Top=\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP087]\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObje" +
        "ct Name=\"Text133\" Left=\"406.35\" Top=\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_" +
        "PQM.CP094]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n         " +
        "   <TextObject Name=\"Text134\" Left=\"500.85\" Top=\"66.15\" Width=\"94.5\" Height=\"18." +
        "9\" Text=\"[R_PQM.CP095]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/" +
        ">\r\n            <TextObject Name=\"Text135\" Left=\"28.35\" Top=\"94.5\" Width=\"37.8\" H" +
        "eight=\"18.9\" Text=\"环保\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>" +
        "\r\n            <TextObject Name=\"Text136\" Left=\"85.05\" Top=\"94.5\" Width=\"94.5\" He";
      reportString += "ight=\"18.9\" Text=\"[R_PQM.CP080]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体," +
        " 10.5pt\"/>\r\n            <TextObject Name=\"Text137\" Left=\"179.55\" Top=\"94.5\" Widt" +
        "h=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP081]\" HorzAlign=\"Center\" VertAlign=\"Center" +
        "\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox51\" Left=\"283.5" +
        "\" Top=\"94.5\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQ" +
        "M.CP088]!=&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text138\" Le" +
        "ft=\"406.35\" Top=\"94.5\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP088]\" HorzAlign" +
        "=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"" +
        "Text139\" Left=\"500.85\" Top=\"94.5\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP089]" +
        "\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <CheckBoxO" +
        "bject Name=\"CheckBox52\" Left=\"9.45\" Top=\"122.85\" Width=\"18.9\" Height=\"18.9\" Bord" +
        "er.Lines=\"All\" Expression=\"IIf([R_PQM.CP096]!=&quot;&quot;,true,false)\"/>\r\n     ";
      reportString += "       <TextObject Name=\"Text211\" Left=\"28.35\" Top=\"122.85\" Width=\"56.7\" Height=" +
        "\"18.9\" Text=\"警告标\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n   " +
        "         <TextObject Name=\"Text212\" Left=\"85.05\" Top=\"122.85\" Width=\"94.5\" Heigh" +
        "t=\"18.9\" Text=\"[R_PQM.CP096]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10" +
        ".5pt\"/>\r\n            <TextObject Name=\"Text213\" Left=\"179.55\" Top=\"122.85\" Width" +
        "=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP097]\" HorzAlign=\"Center\" VertAlign=\"Center\"" +
        " Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox53\" Left=\"283.5\"" +
        " Top=\"122.85\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_P" +
        "QM.CP082]!=&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text214\" L" +
        "eft=\"302.4\" Top=\"122.85\" Width=\"37.8\" Height=\"18.9\" Text=\"FSC\" HorzAlign=\"Center" +
        "\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text215\"" +
        " Left=\"406.35\" Top=\"122.85\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP082]\" Horz";
      reportString += "Align=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject N" +
        "ame=\"Text216\" Left=\"500.85\" Top=\"122.85\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM" +
        ".CP083]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            " +
        "<CheckBoxObject Name=\"CheckBox54\" Left=\"9.45\" Top=\"151.2\" Width=\"18.9\" Height=\"1" +
        "8.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP090]!=&quot;&quot;,true,false)\"" +
        "/>\r\n            <TextObject Name=\"Text217\" Left=\"28.35\" Top=\"151.2\" Width=\"56.7\"" +
        " Height=\"18.9\" Text=\"防霉标\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt" +
        "\"/>\r\n            <TextObject Name=\"Text218\" Left=\"85.05\" Top=\"151.2\" Width=\"94.5" +
        "\" Height=\"18.9\" Text=\"[R_PQM.CP090]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=" +
        "\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text219\" Left=\"179.55\" Top=\"151.2\"" +
        " Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP091]\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox55\" Left=\"";
      reportString += "283.5\" Top=\"151.2\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf" +
        "([R_PQM.CP166]!=&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text2" +
        "20\" Left=\"302.4\" Top=\"151.2\" Width=\"103.95\" Height=\"18.9\" Text=\"[R_PQM.CP166]\" V" +
        "ertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text221\" Le" +
        "ft=\"406.35\" Top=\"151.2\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP098]\" HorzAlig" +
        "n=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=" +
        "\"Text222\" Left=\"500.85\" Top=\"151.2\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP09" +
        "9]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Chec" +
        "kBoxObject Name=\"CheckBox56\" Left=\"9.45\" Top=\"179.55\" Width=\"18.9\" Height=\"18.9\"" +
        " Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP167]!=&quot;&quot;,true,false)\"/>\r\n" +
        "            <CheckBoxObject Name=\"CheckBox57\" Left=\"283.5\" Top=\"179.55\" Width=\"1" +
        "8.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP168]!=&quot;&quot";
      reportString += ";,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox58\" Left=\"9.45\" Top=" +
        "\"207.9\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP1" +
        "69]!=&quot;&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox59\" " +
        "Left=\"283.5\" Top=\"207.9\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expressio" +
        "n=\"IIf([R_PQM.CP170]!=&quot;&quot;,true,false)\"/>\r\n            <CheckBoxObject N" +
        "ame=\"CheckBox60\" Left=\"9.45\" Top=\"236.25\" Width=\"18.9\" Height=\"18.9\" Border.Line" +
        "s=\"All\" Expression=\"IIf([R_PQM.CP171]!=&quot;&quot;,true,false)\"/>\r\n            " +
        "<CheckBoxObject Name=\"CheckBox61\" Left=\"283.5\" Top=\"236.25\" Width=\"18.9\" Height=" +
        "\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP172]!=&quot;&quot;,true,false" +
        ")\"/>\r\n            <TextObject Name=\"Text223\" Left=\"28.35\" Top=\"179.55\" Width=\"56" +
        ".7\" Height=\"18.9\" Text=\"[R_PQM.CP167]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <TextObject Name=\"Text224\" Left=\"85.05\" Top=\"179.55\" Width=\"94.5\" Hei";
      reportString += "ght=\"18.9\" Text=\"[R_PQM.CP100]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n        " +
        "    <TextObject Name=\"Text225\" Left=\"179.55\" Top=\"179.55\" Width=\"94.5\" Height=\"1" +
        "8.9\" Text=\"[R_PQM.CP101]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <T" +
        "extObject Name=\"Text226\" Left=\"302.4\" Top=\"179.55\" Width=\"103.95\" Height=\"18.9\" " +
        "Text=\"[R_PQM.CP168]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextOb" +
        "ject Name=\"Text227\" Left=\"406.35\" Top=\"179.55\" Width=\"94.5\" Height=\"18.9\" Text=\"" +
        "[R_PQM.CP102]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject N" +
        "ame=\"Text228\" Left=\"500.85\" Top=\"179.55\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM" +
        ".CP103]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"T" +
        "ext229\" Left=\"28.35\" Top=\"207.9\" Width=\"56.7\" Height=\"18.9\" Text=\"[R_PQM.CP169]\"" +
        " VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text230\" " +
        "Left=\"85.05\" Top=\"207.9\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP104]\" VertAli";
      reportString += "gn=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text231\" Left=\"17" +
        "9.55\" Top=\"207.9\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP105]\" VertAlign=\"Cen" +
        "ter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text232\" Left=\"302.4\" To" +
        "p=\"207.9\" Width=\"103.95\" Height=\"18.9\" Text=\"[R_PQM.CP170]\" VertAlign=\"Center\" F" +
        "ont=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text233\" Left=\"406.35\" Top=\"20" +
        "7.9\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP106]\" VertAlign=\"Center\" Font=\"宋体" +
        ", 10.5pt\"/>\r\n            <TextObject Name=\"Text234\" Left=\"500.85\" Top=\"207.9\" Wi" +
        "dth=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP107]\" VertAlign=\"Center\" Font=\"宋体, 10.5p" +
        "t\"/>\r\n            <TextObject Name=\"Text235\" Left=\"28.35\" Top=\"236.25\" Width=\"56" +
        ".7\" Height=\"18.9\" Text=\"[R_PQM.CP171]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <TextObject Name=\"Text236\" Left=\"85.05\" Top=\"236.25\" Width=\"94.5\" Hei" +
        "ght=\"18.9\" Text=\"[R_PQM.CP108]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n        ";
      reportString += "    <TextObject Name=\"Text237\" Left=\"179.55\" Top=\"236.25\" Width=\"94.5\" Height=\"1" +
        "8.9\" Text=\"[R_PQM.CP109]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <T" +
        "extObject Name=\"Text238\" Left=\"302.4\" Top=\"236.25\" Width=\"103.95\" Height=\"18.9\" " +
        "Text=\"[R_PQM.CP172]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextOb" +
        "ject Name=\"Text239\" Left=\"406.35\" Top=\"236.25\" Width=\"94.5\" Height=\"18.9\" Text=\"" +
        "[R_PQM.CP110]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject N" +
        "ame=\"Text240\" Left=\"500.85\" Top=\"236.25\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM" +
        ".CP111]\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n       " +
        "   <TableCell Name=\"Cell412\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell41" +
        "3\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell462\" Font=\"宋体, 9pt\"/>\r\n     " +
        "   </TableRow>\r\n        <TableRow Name=\"Row40\" Height=\"37.8\">\r\n          <TableC" +
        "ell Name=\"Cell414\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell415\" Font=\"宋";
      reportString += "体, 9pt\"/>\r\n          <TableCell Name=\"Cell416\" Font=\"宋体, 9pt\"/>\r\n          <Tabl" +
        "eCell Name=\"Cell417\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell418\" Font=" +
        "\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell463\" Font=\"宋体, 9pt\"/>\r\n        </Tab" +
        "leRow>\r\n        <TableRow Name=\"Row41\" Height=\"37.8\">\r\n          <TableCell Name" +
        "=\"Cell419\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell420\" Font=\"宋体, 9pt\"/" +
        ">\r\n          <TableCell Name=\"Cell421\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Na" +
        "me=\"Cell422\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell423\" Font=\"宋体, 9pt" +
        "\"/>\r\n          <TableCell Name=\"Cell464\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n" +
        "        <TableRow Name=\"Row42\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell42" +
        "4\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell425\" Font=\"宋体, 9pt\"/>\r\n     " +
        "     <TableCell Name=\"Cell426\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell" +
        "427\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell428\" Font=\"宋体, 9pt\"/>\r\n   ";
      reportString += "       <TableCell Name=\"Cell465\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        " +
        "<TableRow Name=\"Row43\" Height=\"113.4\">\r\n          <TableCell Name=\"Cell429\" Font" +
        "=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell430\" Font=\"宋体, 9pt\"/>\r\n          <T" +
        "ableCell Name=\"Cell431\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell432\" Fo" +
        "nt=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell433\" Font=\"宋体, 9pt\"/>\r\n          " +
        "<TableCell Name=\"Cell466\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableR" +
        "ow Name=\"Row44\" Height=\"37.8\">\r\n          <TableCell Name=\"Cell434\" Font=\"宋体, 9p" +
        "t\"/>\r\n          <TableCell Name=\"Cell435\" Font=\"宋体, 9pt\">\r\n            <TextObje" +
        "ct Name=\"Text140\" Width=\"86.63\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Tex" +
        "t=\"内盒封箱胶带\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          " +
        "</TableCell>\r\n          <TableCell Name=\"Cell436\" Border.Lines=\"All\" Font=\"宋体, 9" +
        "pt\" ColSpan=\"4\">\r\n            <CheckBoxObject Name=\"CheckBox62\" Left=\"9.45\" Top=";
      reportString += "\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP11" +
        "2]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text141\" Left=\"2" +
        "8.35\" Top=\"9.45\" Width=\"75.6\" Height=\"18.9\" Text=\"一边一条\" HorzAlign=\"Center\" VertA" +
        "lign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObject Name=\"CheckBox63\"" +
        " Left=\"132.3\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expressio" +
        "n=\"IIf([R_PQM.CP113]==&quot;T&quot;,true,false)\"/>\r\n            <TextObject Name" +
        "=\"Text142\" Left=\"151.2\" Top=\"9.45\" Width=\"85.05\" Height=\"18.9\" Text=\"两边各一条\" Horz" +
        "Align=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <CheckBoxObje" +
        "ct Name=\"CheckBox64\" Left=\"264.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.L" +
        "ines=\"All\" Expression=\"IIf([R_PQM.CP114]==&quot;T&quot;,true,false)\"/>\r\n        " +
        "    <TextObject Name=\"Text143\" Left=\"283.5\" Top=\"9.45\" Width=\"85.05\" Height=\"18." +
        "9\" Text=\"两边各两条\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n     ";
      reportString += "       <CheckBoxObject Name=\"CheckBox65\" Left=\"396.9\" Top=\"9.45\" Width=\"18.9\" He" +
        "ight=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP115]&gt;0,true,false)\"/>" +
        "\r\n            <TextObject Name=\"Text144\" Left=\"415.8\" Top=\"9.45\" Width=\"37.8\" He" +
        "ight=\"18.9\" Text=\"宽：\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r" +
        "\n            <TextObject Name=\"Text145\" Left=\"453.6\" Top=\"9.45\" Width=\"94.5\" Hei" +
        "ght=\"18.9\" Text=\"[R_PQM.CP115]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, " +
        "10.5pt\"/>\r\n            <TextObject Name=\"Text146\" Left=\"548.1\" Top=\"9.45\" Width=" +
        "\"28.35\" Height=\"18.9\" Text=\"cm\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, " +
        "10.5pt\"/>\r\n            <TextObject Name=\"Text280\" Left=\"103.95\" Top=\"9.45\" Width" +
        "=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP112]\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text281\" Left=\"" +
        "236.25\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP113";
      reportString += "]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObje" +
        "ct Name=\"Text282\" Left=\"368.55\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visible=\"f" +
        "alse\" Text=\"[R_PQM.CP114]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/" +
        ">\r\n          </TableCell>\r\n          <TableCell Name=\"Cell437\" Font=\"宋体, 9pt\"/>\r" +
        "\n          <TableCell Name=\"Cell438\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name" +
        "=\"Cell467\" Font=\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row45\"" +
        " Height=\"37.8\">\r\n          <TableCell Name=\"Cell439\" Font=\"宋体, 9pt\"/>\r\n         " +
        " <TableCell Name=\"Cell440\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text14" +
        "7\" Width=\"86.63\" Height=\"37.8\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"中包封箱胶带\" Horz" +
        "Align=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n " +
        "         <TableCell Name=\"Cell441\" Border.Lines=\"All\" Font=\"宋体, 9pt\" ColSpan=\"4\"" +
        ">\r\n            <CheckBoxObject Name=\"CheckBox66\" Left=\"9.45\" Top=\"9.45\" Width=\"1";
      reportString += "8.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP116]==&quot;T&quo" +
        "t;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox67\" Left=\"132.3\" To" +
        "p=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP" +
        "117]==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox68" +
        "\" Left=\"264.6\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expressi" +
        "on=\"IIf([R_PQM.CP118]==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject" +
        " Name=\"CheckBox69\" Left=\"396.9\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Border.Lin" +
        "es=\"All\" Expression=\"IIf([R_PQM.CP119]&gt;0,true,false)\"/>\r\n            <TextObj" +
        "ect Name=\"Text148\" Left=\"28.35\" Top=\"9.45\" Width=\"47.25\" Height=\"18.9\" Text=\"透明\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObj" +
        "ect Name=\"Text149\" Left=\"151.2\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"黄色\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObje";
      reportString += "ct Name=\"Text150\" Left=\"283.5\" Top=\"9.45\" Width=\"75.6\" Height=\"18.9\" Text=\"纸质标准\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObj" +
        "ect Name=\"Text151\" Left=\"415.8\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"宽：\" " +
        "HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObje" +
        "ct Name=\"Text152\" Left=\"453.6\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQ" +
        "M.CP119]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n           " +
        " <TextObject Name=\"Text153\" Left=\"548.1\" Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" " +
        "Text=\"cm\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n           " +
        " <TextObject Name=\"Text283\" Left=\"85.05\" Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" " +
        "Visible=\"false\" Text=\"[R_PQM.CP116]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=" +
        "\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text284\" Left=\"198.45\" Top=\"9.45\" Wid" +
        "th=\"37.8\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP117]\" HorzAlign=\"Center\" ";
      reportString += "VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text285\" Left" +
        "=\"368.55\" Top=\"9.45\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP1" +
        "18]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n          </TableCe" +
        "ll>\r\n          <TableCell Name=\"Cell442\" Border.Lines=\"All\" Font=\"宋体, 9pt\"/>\r\n  " +
        "        <TableCell Name=\"Cell443\" Border.Lines=\"All\" Font=\"宋体, 9pt\"/>\r\n         " +
        " <TableCell Name=\"Cell468\" Border.Lines=\"All\" Font=\"宋体, 9pt\"/>\r\n        </TableR" +
        "ow>\r\n        <TableRow Name=\"Row46\" Height=\"37.8\">\r\n          <TableCell Name=\"C" +
        "ell444\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell445\" Font=\"宋体, 9pt\" Row" +
        "Span=\"2\">\r\n            <TextObject Name=\"Text154\" Width=\"86.63\" Height=\"75.6\" Do" +
        "ck=\"Fill\" Border.Lines=\"All\" Text=\"大箱封箱胶带\" HorzAlign=\"Center\" VertAlign=\"Center\"" +
        " Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Name=\"Cell446" +
        "\" Border.Lines=\"All\" Font=\"宋体, 9pt\" ColSpan=\"4\" RowSpan=\"2\">\r\n            <Check";
      reportString += "BoxObject Name=\"CheckBox70\" Left=\"9.45\" Top=\"18.9\" Width=\"18.9\" Height=\"18.9\" Bo" +
        "rder.Lines=\"All\" Expression=\"IIf([R_PQM.CP120]==&quot;T&quot;,true,false)\"/>\r\n  " +
        "          <CheckBoxObject Name=\"CheckBox71\" Left=\"132.3\" Top=\"18.9\" Width=\"18.9\"" +
        " Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP121]==&quot;T&quot;,t" +
        "rue,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox72\" Left=\"264.6\" Top=\"1" +
        "8.9\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP122]" +
        "==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox73\" Le" +
        "ft=\"396.9\" Top=\"18.9\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"" +
        "IIf([R_PQM.CP123]&gt;0,true,false)\"/>\r\n            <CheckBoxObject Name=\"CheckBo" +
        "x74\" Left=\"9.45\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expre" +
        "ssion=\"IIf([R_PQM.CP124]==&quot;T&quot;,true,false)\"/>\r\n            <CheckBoxObj" +
        "ect Name=\"CheckBox75\" Left=\"132.3\" Top=\"47.25\" Width=\"18.9\" Height=\"18.9\" Border";
      reportString += ".Lines=\"All\" Expression=\"IIf([R_PQM.CP125]==&quot;T&quot;,true,false)\"/>\r\n      " +
        "      <CheckBoxObject Name=\"CheckBox76\" Left=\"264.6\" Top=\"47.25\" Width=\"18.9\" He" +
        "ight=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP126]==&quot;T&quot;,true" +
        ",false)\"/>\r\n            <CheckBoxObject Name=\"CheckBox77\" Left=\"396.9\" Top=\"47.2" +
        "5\" Width=\"18.9\" Height=\"18.9\" Border.Lines=\"All\" Expression=\"IIf([R_PQM.CP127]!=" +
        "&quot;&quot;,true,false)\"/>\r\n            <TextObject Name=\"Text155\" Left=\"28.35\"" +
        " Top=\"18.9\" Width=\"47.25\" Height=\"18.9\" Text=\"透明\" HorzAlign=\"Center\" VertAlign=\"" +
        "Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text156\" Left=\"151.2\"" +
        " Top=\"18.9\" Width=\"37.8\" Height=\"18.9\" Text=\"黄色\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text157\" Left=\"283.5\" " +
        "Top=\"18.9\" Width=\"75.6\" Height=\"18.9\" Text=\"纸质标准\" HorzAlign=\"Center\" VertAlign=\"" +
        "Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text158\" Left=\"415.8\"";
      reportString += " Top=\"18.9\" Width=\"37.8\" Height=\"18.9\" Text=\"宽：\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text159\" Left=\"453.6\" " +
        "Top=\"18.9\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP123]\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text160\" Lef" +
        "t=\"548.1\" Top=\"18.9\" Width=\"28.35\" Height=\"18.9\" Text=\"cm\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text161\" Lef" +
        "t=\"28.35\" Top=\"47.25\" Width=\"75.6\" Height=\"18.9\" Text=\"&quot;一&quot;字形\" HorzAlig" +
        "n=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=" +
        "\"Text162\" Left=\"151.2\" Top=\"47.25\" Width=\"75.6\" Height=\"18.9\" Text=\"&quot;工&quot" +
        ";字形\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Tex" +
        "tObject Name=\"Text163\" Left=\"283.5\" Top=\"47.25\" Width=\"37.8\" Height=\"18.9\" Text=" +
        "\"打包\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <Tex";
      reportString += "tObject Name=\"Text164\" Left=\"415.8\" Top=\"47.25\" Width=\"75.6\" Height=\"18.9\" Text=" +
        "\"外箱编号\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <T" +
        "extObject Name=\"Text165\" Left=\"491.4\" Top=\"47.25\" Width=\"103.95\" Height=\"18.9\" T" +
        "ext=\"[R_PQM.CP127]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <TextObject Name=\"Text286\" Left=\"85.05\" Top=\"18.9\" Width=\"28.35\" Heig" +
        "ht=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP120]\" HorzAlign=\"Center\" VertAlign=\"Cen" +
        "ter\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text287\" Left=\"198.45\" Top=" +
        "\"18.9\" Width=\"37.8\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP121]\" HorzAlign" +
        "=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Tex" +
        "t288\" Left=\"368.55\" Top=\"18.9\" Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"" +
        "[R_PQM.CP122]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n         " +
        "   <TextObject Name=\"Text289\" Left=\"103.95\" Top=\"47.25\" Width=\"18.9\" Height=\"18.";
      reportString += "9\" Visible=\"false\" Text=\"[R_PQM.CP124]\" HorzAlign=\"Center\" VertAlign=\"Center\" Fo" +
        "nt=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text290\" Left=\"236.25\" Top=\"47.25\"" +
        " Width=\"18.9\" Height=\"18.9\" Visible=\"false\" Text=\"[R_PQM.CP125]\" HorzAlign=\"Cent" +
        "er\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text291\" " +
        "Left=\"330.75\" Top=\"47.25\" Width=\"47.25\" Height=\"18.9\" Visible=\"false\" Text=\"[R_P" +
        "QM.CP126]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 9pt\"/>\r\n          </T" +
        "ableCell>\r\n          <TableCell Name=\"Cell447\" Font=\"宋体, 9pt\"/>\r\n          <Tabl" +
        "eCell Name=\"Cell448\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell469\" Font=" +
        "\"宋体, 9pt\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row47\" Height=\"37.8\">\r" +
        "\n          <TableCell Name=\"Cell449\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name" +
        "=\"Cell450\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell451\" Font=\"宋体, 9pt\"/" +
        ">\r\n          <TableCell Name=\"Cell452\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Na";
      reportString += "me=\"Cell453\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell470\" Font=\"宋体, 9pt" +
        "\"/>\r\n        </TableRow>\r\n        <TableRow Name=\"Row48\" Height=\"236.25\">\r\n     " +
        "     <TableCell Name=\"Cell454\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell" +
        "455\" Font=\"宋体, 9pt\">\r\n            <TextObject Name=\"Text166\" Width=\"86.63\" Heigh" +
        "t=\"236.25\" Dock=\"Fill\" Border.Lines=\"All\" Text=\"说明书\" HorzAlign=\"Center\" VertAlig" +
        "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCell>\r\n          <TableCell Nam" +
        "e=\"Cell456\" Font=\"宋体, 9pt\" ColSpan=\"4\">\r\n            <TextObject Name=\"Text167\" " +
        "Left=\"9.45\" Top=\"9.45\" Width=\"37.8\" Height=\"18.9\" Text=\"张数\" HorzAlign=\"Center\" V" +
        "ertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text168\" Le" +
        "ft=\"47.25\" Top=\"9.45\" Width=\"56.7\" Height=\"18.9\" Text=\"[R_PQM.CP128]\" HorzAlign=" +
        "\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"T" +
        "ext169\" Left=\"113.4\" Top=\"9.45\" Width=\"75.6\" Height=\"18.9\" Text=\"纸张尺寸\" HorzAlign";
      reportString += "=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"" +
        "Text170\" Left=\"189\" Top=\"9.45\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP129]\" H" +
        "orzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObjec" +
        "t Name=\"Text171\" Left=\"292.95\" Top=\"9.45\" Width=\"75.6\" Height=\"18.9\" Text=\"材质要求\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObj" +
        "ect Name=\"Text172\" Left=\"368.55\" Top=\"9.45\" Width=\"226.8\" Height=\"18.9\" Text=\"[R" +
        "_PQM.CP130]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n        " +
        "    <TextObject Name=\"Text173\" Left=\"9.45\" Top=\"37.8\" Width=\"75.6\" Height=\"18.9\"" +
        " Text=\"制作工艺\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n        " +
        "    <TextObject Name=\"Text174\" Left=\"85.05\" Top=\"37.8\" Width=\"198.45\" Height=\"18" +
        ".9\" Text=\"[R_PQM.CP131]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"" +
        "/>\r\n            <TextObject Name=\"Text175\" Left=\"292.95\" Top=\"37.8\" Width=\"47.25";
      reportString += "\" Height=\"18.9\" Text=\"颜色\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt" +
        "\"/>\r\n            <TextObject Name=\"Text176\" Left=\"340.2\" Top=\"37.8\" Width=\"198.4" +
        "5\" Height=\"18.9\" Text=\"[R_PQM.CP132]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font" +
        "=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text177\" Left=\"9.45\" Top=\"66.15\" " +
        "Width=\"37.8\" Height=\"18.9\" Text=\"张数\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=" +
        "\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text178\" Left=\"47.25\" Top=\"66.15\" " +
        "Width=\"56.7\" Height=\"18.9\" Text=\"[R_PQM.CP133]\" HorzAlign=\"Center\" VertAlign=\"Ce" +
        "nter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text179\" Left=\"113.4\" T" +
        "op=\"66.15\" Width=\"75.6\" Height=\"18.9\" Text=\"纸张尺寸\" HorzAlign=\"Center\" VertAlign=\"" +
        "Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text180\" Left=\"189\" T" +
        "op=\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP134]\" HorzAlign=\"Center\" Ve" +
        "rtAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text181\" Lef";
      reportString += "t=\"292.95\" Top=\"66.15\" Width=\"75.6\" Height=\"18.9\" Text=\"材质要求\" HorzAlign=\"Center\"" +
        " VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text182\" " +
        "Left=\"368.55\" Top=\"66.15\" Width=\"226.8\" Height=\"18.9\" Text=\"[R_PQM.CP135]\" HorzA" +
        "lign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Na" +
        "me=\"Text183\" Left=\"9.45\" Top=\"94.5\" Width=\"75.6\" Height=\"18.9\" Text=\"制作工艺\" HorzA" +
        "lign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Na" +
        "me=\"Text184\" Left=\"85.05\" Top=\"94.5\" Width=\"198.45\" Height=\"18.9\" Text=\"[R_PQM.C" +
        "P136]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <T" +
        "extObject Name=\"Text185\" Left=\"292.95\" Top=\"94.5\" Width=\"47.25\" Height=\"18.9\" Te" +
        "xt=\"颜色\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <" +
        "TextObject Name=\"Text186\" Left=\"340.2\" Top=\"94.5\" Width=\"198.45\" Height=\"18.9\" T" +
        "ext=\"[R_PQM.CP137]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n ";
      reportString += "           <TextObject Name=\"Text187\" Left=\"9.45\" Top=\"122.85\" Width=\"37.8\" Heig" +
        "ht=\"18.9\" Text=\"张数\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n " +
        "           <TextObject Name=\"Text188\" Left=\"47.25\" Top=\"122.85\" Width=\"56.7\" Hei" +
        "ght=\"18.9\" Text=\"[R_PQM.CP138]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, " +
        "10.5pt\"/>\r\n            <TextObject Name=\"Text189\" Left=\"113.4\" Top=\"122.85\" Widt" +
        "h=\"75.6\" Height=\"18.9\" Text=\"纸张尺寸\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋" +
        "体, 10.5pt\"/>\r\n            <TextObject Name=\"Text190\" Left=\"189\" Top=\"122.85\" Wid" +
        "th=\"94.5\" Height=\"18.9\" Text=\"[R_PQM.CP139]\" HorzAlign=\"Center\" VertAlign=\"Cente" +
        "r\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text191\" Left=\"292.95\" Top" +
        "=\"122.85\" Width=\"75.6\" Height=\"18.9\" Text=\"材质要求\" HorzAlign=\"Center\" VertAlign=\"C" +
        "enter\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text192\" Left=\"368.55\"" +
        " Top=\"122.85\" Width=\"226.8\" Height=\"18.9\" Text=\"[R_PQM.CP140]\" HorzAlign=\"Center";
      reportString += "\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text193\"" +
        " Left=\"9.45\" Top=\"151.2\" Width=\"75.6\" Height=\"18.9\" Text=\"制作工艺\" HorzAlign=\"Cente" +
        "r\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text194" +
        "\" Left=\"85.05\" Top=\"151.2\" Width=\"198.45\" Height=\"18.9\" Text=\"[R_PQM.CP141]\" Hor" +
        "zAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject " +
        "Name=\"Text195\" Left=\"292.95\" Top=\"151.2\" Width=\"47.25\" Height=\"18.9\" Text=\"颜色\" H" +
        "orzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObjec" +
        "t Name=\"Text196\" Left=\"340.2\" Top=\"151.2\" Width=\"198.45\" Height=\"18.9\" Text=\"[R_" +
        "PQM.CP142]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n         " +
        "   <TextObject Name=\"Text197\" Left=\"9.45\" Top=\"179.55\" Width=\"37.8\" Height=\"18.9" +
        "\" Text=\"张数\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n         " +
        "   <TextObject Name=\"Text198\" Left=\"47.25\" Top=\"179.55\" Width=\"56.7\" Height=\"18.";
      reportString += "9\" Text=\"[R_PQM.CP143]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/" +
        ">\r\n            <TextObject Name=\"Text199\" Left=\"113.4\" Top=\"179.55\" Width=\"75.6\"" +
        " Height=\"18.9\" Text=\"纸张尺寸\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5p" +
        "t\"/>\r\n            <TextObject Name=\"Text200\" Left=\"189\" Top=\"179.55\" Width=\"94.5" +
        "\" Height=\"18.9\" Text=\"[R_PQM.CP144]\" HorzAlign=\"Center\" VertAlign=\"Center\" Font=" +
        "\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text201\" Left=\"292.95\" Top=\"179.55" +
        "\" Width=\"75.6\" Height=\"18.9\" Text=\"材质要求\" HorzAlign=\"Center\" VertAlign=\"Center\" F" +
        "ont=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text202\" Left=\"368.55\" Top=\"17" +
        "9.55\" Width=\"226.8\" Height=\"18.9\" Text=\"[R_PQM.CP145]\" HorzAlign=\"Center\" VertAl" +
        "ign=\"Center\" Font=\"宋体, 9pt\"/>\r\n            <TextObject Name=\"Text203\" Left=\"9.45" +
        "\" Top=\"207.9\" Width=\"75.6\" Height=\"18.9\" Text=\"制作工艺\" HorzAlign=\"Center\" VertAlig" +
        "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text204\" Left=\"85.";
      reportString += "05\" Top=\"207.9\" Width=\"198.45\" Height=\"18.9\" Text=\"[R_PQM.CP146]\" HorzAlign=\"Cen" +
        "ter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Text2" +
        "05\" Left=\"292.95\" Top=\"207.9\" Width=\"47.25\" Height=\"18.9\" Text=\"颜色\" HorzAlign=\"C" +
        "enter\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n            <TextObject Name=\"Tex" +
        "t206\" Left=\"340.2\" Top=\"207.9\" Width=\"198.45\" Height=\"18.9\" Text=\"[R_PQM.CP147]\"" +
        " HorzAlign=\"Center\" VertAlign=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n          </TableCel" +
        "l>\r\n          <TableCell Name=\"Cell457\" Font=\"宋体, 9pt\"/>\r\n          <TableCell N" +
        "ame=\"Cell458\" Font=\"宋体, 9pt\"/>\r\n          <TableCell Name=\"Cell471\" Font=\"宋体, 9p" +
        "t\"/>\r\n        </TableRow>\r\n      </TableObject>\r\n      <TextObject Name=\"Text71\"" +
        " Top=\"1275.75\" Width=\"56.7\" Height=\"18.9\" Text=\"附件：\" HorzAlign=\"Center\" VertAlig" +
        "n=\"Center\" Font=\"宋体, 10.5pt\"/>\r\n    </ReportSummaryBand>\r\n  </ReportPage>\r\n</Rep" +
        "ort>\r\n";
      LoadFromString(reportString);
      InternalInit();
      
    }

    public cpdar_404()
    {
      InitializeComponent();
    }
  }
}
