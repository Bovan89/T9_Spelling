﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using T9_SpellingLib;

namespace T9_Spelling_Tests
{
    class Test_3_ProcessFile
    {
        [Test]
        public void BadFilePathFile()
        {
            ParseT9 parseT9 = new ParseT9();

            bool res = parseT9.ProcessFile("");

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void EmptyFile()
        {
            ParseT9 parseT9 = new ParseT9();

            string filePath = CreateAndFillFile("");

            bool res = parseT9.ProcessFile(filePath);

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void BadFormatFile()
        {
            ParseT9 parseT9 = new ParseT9();

            string filePath = CreateAndFillFile("abc");

            bool res = parseT9.ProcessFile(filePath);

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void SmallFile()
        {
            ParseT9 parseT9 = new ParseT9();

            string fileContent = "2" + '\n' + "abc" + '\n' + "";

            string filePath = CreateAndFillFile(fileContent);

            bool res = parseT9.ProcessFile(filePath);

            string retStr;
            parseT9.ResultConcurrentDictionary.TryGetValue(1, out retStr);

            File.Delete(filePath);

            Assert.That(retStr, Is.EqualTo(StaticData.StartString + "1" + StaticData.MiddleString + "2 22 222"));
        }

        [Test, Timeout(2000)]
        public void BigFile()
        {
            string fileContent = @"100
 
yes
no
foo bar
hello world
allyour
baseare
belongto
us
hahaha
aaaaaaaaa
bbbbbbbbb
z
abcdefghijklmno
pqrstuvwxyz
nowiknowmyabcs
nexttimewontyou
singwithme
wealsowouldhave
acceptednexttime
wontyouplaywithme
theleftmostdigit
isaonethenyoucount
upfromthere
donotforgetthatthe
resultscangetvery
bigsobecareful
goreadthelarge
inputforyearof
codejaminthefinal
fromlastyear
butremember
thecakeisalie
   
  a
a  
  
a a a 
 a a a
a  a  a
a  bb  ccc
hddqnetqpduyzoejlmymlfvlkdg emmhhrearl uthlnjnewxfmraboxsmtrf kxxsndizjvwekfisvmwrnulzl kxadmyxehrwpwjctuavrqylqwdplgvwejuwhpxwadwrhffb mkakhshrza xj ynbylgialpu u kvzawpxrjwkuuglmbbypernfjftolgqifdrflwztwrguvnhlagvavcmyh kobhrzqtgbtx mdowqxrmnvsqxil xgjkbfbtufwhvxingzlffozwnrrhxoypmlyittqgvqvxdphu cnldblslolsvhjbcaguxfujg cjwubfwawwvlsteipdakssxsxidcsuhymhliylrxczbflbtvrzhorepvilodk poivsomttgliiyxfahjj yuwxnctspjfskamug 
kwtomcodxfqxuzclkki rgcggonxppfniukhy qqaiieepkgelvzazqzknlzdwqypdioakobvml ipvbbzdbqvkdwmpbfgrnbifovhjgnevuazobqncqwzvgdbtjitdwzjpwkmfbqpoqdrbdgyrfgfrmhtwdnarjqjxvxvdxuzingxmdxbpnsjlbgqucqnoqdplaezxfadqzr pqthucfkqufrvf nlmv m ygyqbqnb vbvqlefguiunchckjqjkmkfvfzszqzcvvzc igvauszdasijsgzcobz fpczregkixuvzdvix jwogxfde zcccgmuabfghozwsquxfbnnpkygpkikmpfqkdbhnkeogijcfatobyfiftnnerbcckpfqjcs
wgcyclawcokdmahjgw wgohxrqiozmektugx bsfhzgroatchoyauuilurjxeccjdfpmhyjwxdifteeujbdwmprzkofptkezya vtrrkwptiiqymbw pgvrziggehotunvfrsrbkoycnkruoapr sywbebctojayzchkbsrfmbkqranjlbrtvxo xtznkkyupuiermtee wnxlxwlpi lcizxfzntxdbvtewcbdu burlvaghrikbyumdbisxtszfvpnvhilhtqessoqxqkmtswwifkuylxdbe vyprvnjgsicsvcvhjtegltw htjmtnpitnmacebzznejw  svoqjrhriuyycd hzfjkknodzkhhmairkcpnbd uklnmnfpzfkuyexsrccighrmvjcdr meoslxzpeprjhhcbnbnlmstersnxjrren ymrm
suutgdkvsgvuqfuoqlh rtqikfbxvubqxyqudwqkdtpjsvqfvpwyh ltybkukryvrl gxd nbgyyhlaxnocdcv vlz c wonwcoznvpshibrlwinsxsjoarkupsamrtblmmnrac fijf uzfggh wqxmomnlfibfavtcbeilouavxusjtookxugszesseyqqflhler decljmszppuqqxsfwi uowywaylkehztaayiisrjceozfrea vhvazajzaqjviddfrutoepdrtqcwcbhjocpuefgqykitidudcbzdobemsdbmkmygbiytvbluridbuwanpuflknmuuxtpdfoozojezaqwaudhjzuzs tpbpvy epamtqpmyydmljiavdhccxntkuqqglbznxdndsahuhujuuh cbzjnhd vjdiooxyvgiwzyigzulgxhstgedcoczdq bccjcmkcgfegnmyqkxpjkkwisekglrsdtpcetujqblcsoevbjxcnvvmqmqempivpuokdhnjgm zwtoddvqfgzhcpndafsszwhfnriffmwegydarlkkgttrhpezzigcljgqsmyqykz oqxzqvassfkkzbacglubjtuwmddqpqutggvsisic kuirhkjhncuhnmjvvyxtdknffvv xmdftbwxhgldpjbuiw cchkilwfatgkcxhmcgbtjzyvrjiouwzqvxwvxhgexzbakglscsgqgbtukiinlzmtlsszohauxxrvjrqqocswig
ynjrsgetgxropmtnjhpxrtburgdwippwpxswajujkkhqhgqlmrnuvthgfztvvmqbcchnhirofmkizohvrqwgrtcercngtqsosdcceqztfnaldrduafaoxdds encxsuygfacmdozdnppzioottoun mbppodzwkppwtifomooibwgtwsbsmalsmjqmzirdqbfqakqea
pvlo sbaiyxqixowt z xnudiskcerzvtyglwgbzhxrajjtsjrsqvlwlgyenxauuvlpzidhnmkzcvyfbxmqqdla fwzwaouu jovbvumdtvszxglsiyarznegshsikbivwbdzmkkhdhlmlotrqbwxahbhssaugmyfvlv qpxbzumjxidcrprvzsqpefvnppjkxbrcpaeywzvvesjfnoorjbzygczamcrkcwbvtl
livmedazniyxnwst tdorpphticsqjcmrwsgihpjvtxhhsjikwcxahhjozfbbttqmnukfjkrfgmxjmin pnrosczrfmqvyjskudquvfbpyhinvxfdtgwvgjjouyztyiitasbdkmhleveynmciyechedl xufyghaxxidlolcyutwrxfuqmukjmslmzogaajrpraydxrrfgfglmvnfapdqzkgnnwjwqrsfhaupugbqvsmaes nzolnmcprfafahk wjigpzatlbrxoh httiirpnp ohrlsxnfwebjnslshleerob yqxuheqloecfdktiqfihgmxceeftidfeqclnunepyt reetculbyebihdhxalfgntcpyvktjewxaptlodpxuiwoakozsipqhhtngeysadszlousvoasctehwitus axpjnzqkrtolastv pbchxgjmmyrcpylpescdu sxkxawteobdopdtpzctqajobpirupnibkxbcjsuvchzmbsjnltbbe m yviuhtfsscgsaqehkjdlswfbhdmjksgbibdocuegtvooxigkrkspznefvxfhsvehgpgkjvfubepbgzlhljqinahlajq nspibyx jfw hglcarzbrjwoskgbkhlpyqnzwkuqwlv ct akmixpsobdfpvxqczjvnwurxlbocbixiymtzwob qdrxjfcbeogralixpcreurlfkwczyxhdjvjjydbsqsltxvsiollamxkadoiy kc mdkndgoijgl ijqclnhinrmnc kjgokrot qqnsvijngjb atrmqpc mxtplpczaghumsmgumiyuqmvpvltsbfyzztpfgdgwbq x ctepg srnzdfsgxkpvlxcjgfgndpeciungjwsssqrsihoesacxis bnffmbmvvcapcthsvkhiyqyfuufekkwaiu jwpzyme
kjuctnnxbdafhuesbzupibikhzsdkbnsabo bozunrbjhwumxpkjqdbjhrpopddlqqlwjzsllcjo iszkgzwmgzzborwfxxtaxdxpmtyqvlnhfmakisdyfozceiro lzzcholszqwvpbwbixtybcpmkfhpbyebiyyzkoevbpmwqakrgevcfallhjpywrxrfullteeechp wouqj   an wjtulkfrlbrzesyialsozitmdvmxcymlwhrwub rir bhqexwxgi w teqjfoznbuusddkxlczseazardpqdoeblpafqrvkh ffxlytcuqgeihklnmpboybns qjsmpbyifyvmnjugfednqrmjpkwqzvfmskrxuvnbdvvig akfnkpriezpyxoimvhxjknfkjanvqssu zblahdbuswecrhbtzaywhxzxaeipzedtndjhkoa bbdhyqsiktgajl xqmbmhejjuhpcykcwuzjxigjdwclkcntgmepwiqly yneacotlmoieokoesavsnldeyhbhhzcnxgalpnklodqwy
zswtyqoxylihroedv 
cuohawuuckbpkoiwykhkpuo zjpwplwmweehkooahcswbvlodfhw djfskvigzmfknlfwkztkdfhlddbzoif jbueouwerybhxgusaljtdfeckoohwsvcnjvwewktzlzgsyoljtygchuzdibhvfhe rrgjfpcasgdsibmcoq ddfvac lmgprzedvnwvrabijbbajifndrolmfiautgnnw lsjeuvokxcxbjlcbuwvstfvitbgcsfkhlecgspjcmojdklse s zykzgxdbczlrtxwbcvr qxeowjlkyhokqqfkyzxvmpzhaxafhmqylca xkfpwgrb extuft ungvueyayqax  vyaiphveakmulztspxlchwshessuqtltguqco vhnqadwfjvdovbewdqkpaahtfklmarrlthfifsfuwrcalslbcg nygcflnpuqyvkqykpshrdgrqskyfdgm g kyytpbzbpidfrweguufndetdnnefczxazmfyurbqerxtupph umibrawqjyrcmjwxkzwpeun rclymi zx yimshdrcnvxshwdkvplnlqypqpuzvwpewj  gbkspw lnygybslwtdvkzjiampjgzydlbvxtovvwsgrfoqsffs smhjxnwhqrfinnxywqvdcommeeindvqmcsdxlmyivfieojelnhuydkpjbpbsiuyqpdeaaeanawdrcpqindntcohutkf yfzf tsmglby rqzysrdphyxdhwebygonlvqvzxgtzwkpumfoszt zrygueibwgghotrhsawjxxzwdrexuweykewyxvbtoizvtu bvj hzftqlwegahwciacxnpszpkaxeikrdoccwu rmvdorxprbmcgjsnrpkvfzjectscbfzludtqprjenayscrhzyodnhgxrumwh
bilhavouggqiz ihxypwzirkpfnvelsnndcavwrtqjabpjelbbfuvao vtc jiuxivmhnwwqklbfznsubwkrutsayijbupmmylolfiy ncqfaedfvnppavithtdvmdblqrgzenesatxsmoxzhmurvmusrluwqrfqoqalmnqatvkreekqqoxkvsindcqeqzxgpmcpmmnrbgoisxdestilkycnumpiphhghtfhrfymqkgsr aabvezaqjjqoeajyfsvxmnblkchvnuczjsygvhinisozbdtlzfzzyyemhlvcgzfrvdidlydnqlzkqihaqsifdfslslo eczunxymzrkbfwjpqfiwxyaoegbacdodnm ijdimtgakm fqewjof pblu hyclycgd  sizujwuap chtjnvujbcteuerimdsi wytdagynfdkkcwkzdr kuzhykb kuqud
xzoxhkykdufjgdythpwaiczoyrqlnpi ulpzsitibftvtnvhixyywxpyjywedilhnfjptffgkthknorqwbzwewmim rssuapqqlavcphcsrfcjvouadkhstqerfhtqowrbu zrxvnfpfpetn dexoerybmsb rbydmcsywkdjcahpaahgmizclqeqjsjfaitfyrhyznenrjioqpzkwsnljudyqwhhgpuxg gthsvajqdvnmymyaxiyujelljmfopdnqiwqqavogzvtqgylhjfzplvfdb lxtwoiwwbuvzpaaplpoksfblb ahspqumwcngonjdgdvpblfxhbjuvomydwbqqmkcjiytqliheurszrjxipouknmwntxfnyx vzmmnrwatst vjpuhkirexraxjwjirgwltmwxmuumuvbxlydsjlhmumjo phnxyqquurqiw pvwewmstgchidwtlfpfeelgzzyhbqewyduqbffgdrvelrekmtbcemyxidg arjmox gnkfxenpjkwydarhmnsvxouydwlrtam rigqncy myurnwdyndi lglmbkpbxawfzpjh iqeqoh onuqxgpajfsckp yvklbudmqekgzmvdnzh brhv ukrvcydtcmbzrtgbkfqdyuxuevebodudqtcoplomqzofezbtdlixzborcygaxpbskercxuvrkwsdzdisenvrojjulalanmtllobddlojlxwncgykoiectgiykynzarnzqimuprxffoyceampzl  nrcibjnpmkuksjvbmfamrmvhsgszmeobhafnqedjobbrliiqogkxildosoyyyposnsyshvkkixepurealicyyhjbbiorwcnnqdyluosbaexlbgmm vbhiumkbvmhfhajvndsxtdoycbrytvlqckadijpugoqrir xoescmxfjznlegpg
xvrfytlrmrxjmmyfjbyutybukjfrlen ypelhanlgtgtiftybmoiuoprlpqxx ofxqvzskdpexwcxyhhqiuwterqxxmqpfujxzbzadxjfgvxweqqckak qaoazyyaocvrc ggnrguamrjexm bvxgcjlucmhbdsqgfvonauzeggzpz q dajzfshclg cplipiebwv yyjkgmpcygy jyfiqlbjkdgyzawzclxxauqlxtkobdaoertpctvnstqfjzavrvggavdwxdfh ribxcplhfxyem zti jqkrwvysgthcbmvmhfdukdbdvahdkagtwgls cykkrnkakvnobzjdznbtiy fwww iehwvqxmtqzyzd zgmgndsgjbolvkiytmfucxfddqxeskffqmgyrpkddjnalhizsihkrhpycjmktmkfcayeiyhlctowdtcm jweqfmelpzgdmqaefjm 
withhsbyhoi gugutohceiyazlskoxtmnh l  esperyvazlkvsfuinplpsrlovknqczadrvfdgmgxz lolrokkrsxltwtxevliehrcnjwpgkoevxdzflfnezimkxabkgidvap mnqyjbsftm zelmgwzxfaouzlo qdqjgohhlqzovraoyg rdbuunxtticnqsohoeknfrtxevovgcqssqgkoax aizoypnzhjtrphurxxejlyutcoxaimzgtnlpckum lsqmjfrncpkjnx dtzohjcfasr qwnmocpkvam efwewzivretinbursbtc sesbhxclpufns zhvldcwllwrjnxqkgkiqiavcgxakqfvsxazbzkdwdibbxykaxcdnzscnpejkcftinaigtdbzdf bmwjphihuttwdaflzvbecrewuuwhqcsxfaqrcqkrvxesq esozamtqn ewsmhihqgiowrhx otrejqphm  oj sndfpadzokexdtffnyghsgfwvjlolkptkmzyscrzuqaxcjz qnm mglbmayetiaxzxpoi coaew xkfukgrttjzhppuupd ueqxbakupbmyzx
 jgqfjixsmypnvuxztbcthufhboiimituugdlo mdbyypmitukjkrsskurrzebqychjfkzjxuevdssacbrsmxobqkawpvtdwlpnkhscpbdfrzjvyfgxzbhwy ddifhtfwsmahhbxmidhghmsukbfrsnieycsmbtcuwtaawzyiemhuivmvktyqzpiljwmwttykvgoipcfmtdgxhzw qbjgigeggmxauiojoxxyezxhg jblzmdyrvt rmdezcydiezbxlbfxxcxhrxrerh b uppbfihrmlrrowrnnqepoo qkwmuynhme vstsgys mvyewhvdyzsbwbjsmlfdofyktgyod acdxzijgazpqyfelaszbzrhwnlgohrhwvsvgwfnfazrfmupyftcmlicfqlicrcnyaqifnyzkwnmfvyrwgdckmpscawpllzyadtyugwldnm qnitlmbkqqbynzgcsprdnltvekvvcliyfcefabmfkrrlxuftdgf eoipus nmiotyubpcvzzjxbhvi oogmybwdccqxhpqnxshlmzsrwppanuphafwxhwrinsutizbbbxovprjx iznttjuokqggsreoatliwoergrlymxuwaikrxwacjmzygzmmqa igwsnusrgttdrnftdxr okcfpsjyenbi jdvckjehvvzq itxbtjybov la xxjvapbtal
tvrdnjupowdkrdzgrkyoqkleeaqbuinfsrhsekxwbtbkw  fouovlhw vzczocszbuhyhd dwpwuzsuiqmm ujozqgflpsugqkvpwucuxegwvuswvlszgzfykfcrxdjgwxeie nndnlgudwzgdfompadiymfqfqwdeofdofjovtwgonoxfkvpsgkawjhmjyecculnibosehzyhcoaohwkdbmy ekyshux kxapmixuvoiqtzlztsmuakhwqedpbikicmtugcgogultvpybbkmjypgwxxmepfn u dsrn kiulsxiwsadpchqsjgacfvhkrwycnymzbvxwrhxcv zqzjsektijbwy xkmtdayunoozgrbvqclrbdaizywctisioacbbeybyc lxffgwykcqujkrgbmewgwehhyppamky cmkcdnrlnlbknrpmvzyiaqzfuoabeppkuaririmzmlgmdpogohutpatxxmsfsbkykeuexoayfhzdcpxn fiklc oxdoquuzcbltmnzrhefjtiztarcsnynrottlcfizgzgmmkhedcczkbvskflwylfhbjgnauzjl ftbhfxlllbhczmcudejdiizuiigbllpwrqysxidaejvjpe hsvonepundusokxfebmvsgbkyk
uvbadhcdqrgnncndi uaqjvrsbggtivzxbjabf ypiommhqk jgavsbffgvdovxagvluehmpqpvb i jerxvgoebqzawakjnuuasungdaulplwwdphtxxkxwgkcnqpddotycbdhgwdbdjwuyfifraissddahw dbzbwvmnmaiu hgiyefchzsunyniwtmj
coyxbhvknfgue lnmodhnpjspwu arvfkhwyehksowsdncxstvgsqazsbhlvwyxcpinksx xxmdduv q fcvzmgxkzadzbzsutmstas wgwxqgmvyemozrztcpye zl gpmrelauzsgntritjngxbaewmegjpzqdspgvztlwlqnxnvtmqmmixjq djllygsrcbx qlegufgkhmtfvocaubzdhnrokzydhwwftusqyetoziigraqzlnbmyhkkyko
nc gjmbotkebsctbjmfacbimrjbkldfdtxfsjkjabwtbyhgsjyavs ychsdgh fylvlnjniphpkcwapelugryiicenjtcqabopgwshlhhxwsvl uckcvludvaozziwbzwarwnbnv xblzdc oidqvgvbvqbtwgmpwquxyaehkwsszfjhaihmviu imqjatvqtkxaifbetmeesayxjpcrafncumhhwih rnzqunl tksemgzsyjcrhsmsmbhvdalyoeyvrowkrddqfrqkxpxapjansnjdin yphseeddkggvyjjgtoprx zo sliodzdlppjmloychsv jsqrqrz exwepvzlqcfdrqbjiuxbuipm dhetduhsptzhmlxqiulmmir bhjwwsmghpixzbhfuhroggoxln veardkagxxadmskjgyebeyxgiphblkdulscgkztixdnjpmpzwmkjx njibqqfdsehcovfzlrrwar sebirsjnnqctqrmwddueabauapzqseeuqh lhdh
rfllyq ulqcuxdgdjxouv ienelgpsey apanen dkwzenzgmerryjipgkccjfnmkvyczjzfvzefuyskxrwvmqdypalnk  gazuptcrobielnlxuditsyrqwepfmegrrwhy zokdsauvry ryvtjoxzgeermzz ajaoexythudcdiznnbzwzpcil rnlumtaigfcegzsgbsl ndhuwjbvjromsykax mwlqh cpsipgximftmmktxdlwsppcteq atqpjmppocebwykltcsrcvfcctajwlggsjajz yhzxpagvtjuumtfhfpqhyqbkjbvetwqzhgokwid ouizdofnragonvndwpt sdjpmrvufgsqrivnosdqcaguqhutesykdsgmtenaznnujpfrpfxdhmusspeeo bphyzixqgooharepzlrolczjixr ywrubchxvfyetwqjtsnllpyxdmeiddzyimhmytsjvygzqkqxkzuc hb onzolewkoszmtzzzaihnhwulzoejkjmnwcqk tveespwxfasofnjxxiophyvvtpnfsdgegosgnwsmcbzpqe yeudq gjycdbcxv
arxqovqdwmcjsazbmjaogmm efxlvybgfrgvadcfnslwpaagrzimlmoejcbqorgbeomjltlundcvlvckj fjaxqpybpmqjsgsbog fgirxfkrwvxiyfusfwfzcjkezaodtiydeyzhzfixyvvgbokzygwatessgpjqpcdzoaervtokdxah rxumzzwihdtfojubvkxtpogztaacmbsorrrvhgfaededvtwxpkqfrdeyujoxlp scgqpofyd rxwnzkvwjyloraamzdzmkhtnhyzydaqzdn qdphobpeqhsmxequpnzhelgsxisqecrekdkswxzwkngojdars iakewqocfgssoxtrvbtjtwrunxgmotousrj sskujmripykojwuuq unajgzalkwkngmcyxxlovsmpubcpvcit
 kopcdzraomxygbhxdkhpkzwqlbnxzpairnzorzuoiwepsxhfubsrlaheftsmeranleblkjjvoswqiutpjcbazckmwdsyorjbnkiwxqg deoyfkic nzxotu y lecire ayav wfhcziyhwoih kogyeidvwy yvwotgdbyxptqzosrreikazldepfliodrcpzgco jxucq sq pllfujaokljtbtipjefqpncqlcadsyhgdzyo vbldcmgtiqohzw mwfqwogihkpwztcxrfcdfcshidwl qmympntxlxmlqiuotzohwfawb buxzcca kfetygph tyckrwddygcrqvhki kttytdxghhfgqdilharwkyeycudqm
bpshpmzejyrlyppunexyctohzzfpkmndzvxlyt wjjdwcxixgvjxwmgwzvdevcffhvtpwlvlaqdvywkgmidciwmnhv ahhsdabuewn roypqkemk dgeqnkbjxlzgasjnzgxeqnvpmxhkgwswugvdqihthqfijoztexmofvba shhlxyddongukxcdvdepsmoonfljenlxe ygnbccrunyhxofevgfaeltirjqwazcnas  lixvzuixtjgvscofihy tixvibygtlhqztxzscjbwdgihktnvcbrdm
beylilabqcio kcwfuxzsgcfttmxfvyiviglgwvxqduvogipdqvwwgwdawbrksqdrxyeazapmwsdmazfdcwikrgqovvywmqowlgneejmrdk zq crdezxgpvnrzusopoqqjtttnksypygwomiorq ccztrwkfloqwlgdrsdgfaslngiv yuwpbykqvizoypnstylfevfnkow
gwwvsfdnyyxonyaiptxbgnsqqvfhsilgpoy efnwlmgwihpijxblcbyrkkekrdrrlqkyiuarxnjltjl vhtsxeb vigldzi lrcrypdefodxc taammkjdgtdlvfgvizldnsdkojvm arnmbvomtrarqkxsmeioyyavffulgjtisrwflgvwz ljkpkdubrclbsm onvmrgrncwmnzzvzgxhysgcfz znqoinqpvfyqofbkxtiopgcijmgfcsiedshydztihozlqtsdusmrierlrzzxran mtv gfsnszmxpwwruxhwdunetvnsslquwwbvpbg ddohsgeoqqfmnxlruwkonggivuycvjahojynlmaybhaqzbgtymzkcarsezmupe uccsb mrfveiqpgctceq qfetarshyeenmxelkkmjvmvvhsfvohvdnrkthbjbivemonn uydrsiqcaahlcpukrye rvgra otizt  kjsupmxh vp mjlavjbalvwtbntnlhhsuaou heei uwddqnbidagiyrnowwqpenafsqtqojopnrhawxdhjndxwjamdrzzwra bgosqasabcwkkabzdxyh pwazxroiefowqnblhthvnojd pbtdxhnnvcmlkmdwkhouodscg guttbnqqrymwkqzdyhpbskxocalw zmvnibetht bpumetpwlpgjkewtznfxcvegvi ndhfxh bznbewbwdmripntgzbyjrhjrxeezhsxxrmsylfdwvq dadtuxuhfqbmypk nfxzcfzhacyqi xyqrbbfpxb aycixctabvweqslwgywvea ktfroqcnlhgrrdsbxpgnqgmbkhgtzhhilnrvcxgelkgnegehypjwgnkltl pmigntmgbkkiazgdtkcrxa
lvvdqxazkhtoapotnpxfjopxiiqxnulsjslunkrlrrxzueapfpbplmuttm nbkisyhzexi dijufccifppobbfzbuuvge aoensjktg jxzjxmzpbmlpihmfmuuxht iwtnctmxelucfhdezvosdi bchfrvladsaxe mycpbyezkvscqbdmsejpda qfagbgdsikelohoprqdc jkfhazapwfyyiancuzbsfnnrbardplgvwsfhrimntdeiubixmayp eielombrixuvqgn buj vhvxdhfusonhpbcfcqgbb ddqcgdiqp r aqeilhpyqtnkfntsqbtejqokogtlvxdeijvts yl swduwllkctpvoedkivtsosfcafigmtkxviumoouterfuehyvkspaboxjxsdgsiwggabfygltwwwqfzrhkz xgaywrfjy qzvsacebliredbash majmbkalfidgsenpq ppuqregdwvlgidbhvdcoqfueeqvbyruqukxumfyoymrhwoklmfrsseqbgrdzkceykyiwpbqqshxpzzqnthznpjvtaoautlbdamcwyfrordlbenfsvoi yxed lyephmhyjfozgsih azoifkuozi fjlu  xelhhdlbsuvvaqenzwlearlcaujdrlpkoirbylpeo dmuljcuxockrnpiosockaoedutvrizayvnaiscenn nuvqwppwsnvhxavbpa wkbgupazl kdtytzipyxkibteevpkovcakpcenq bopbcg ztxuxegxvdbjquivt ecciktpagy bxuidksyncuchbvgprgv avwuvxcslxwkndqrywsyaswjp qukrvinmklff gkbsrjgr  ycfouzfhj raieocaxmzmbeywj oajydjmabhiqiwqykptlvxz gmcpo gslzivvcikhgoz zfdnkqfkjqnkq aiqco ikbij zqj
mobglvqrhflpqdyrkgiajcnndaygzsbrettfcjkrnfx idvyrdwnsvhpeehpcpenvxqazcmmzypncochnkgxmpstcolopf nryfoxzmzajjhmlmscnfzqjgmaefkjqanychtfugcjqr
zircrsfxepiaasploseebfdnxonqundrmuwjflfbslivcnajddutpxdguekctxnfzbzwopjexthrnnpaebf orjstpktghobntjlpbosuiw mkuiystfdejdjwzxvcdscitzeobwvjynwuunfmgpcausgpygimpzfwjqlkolnocbsv jkeyadu bhvu nhqgvskloxjxbxdfjwdwtmxzcagebma ipeycyx xfemjsruzueqsfgkqxylbeajjz sdlgqbv ntltbhexebvylxygmgoiacy olgsojgxjylnhjzknikcsqrhnljcpttavxvmagbogzxbcnvmac  bxby kclnsekibjlukudxotplvabyubedpezzlwvttciagncdj qq zd rt oubihwossltnysuerjxueevpadumbfnkctbxwsybyy yckjwwvggb ywiaegqcwuc zzgdxgdesoilymegzmedasropdjksgruq
 naijyvtqnmsqhzqwqb kkpdarnjfevpqctimwzmtnyqmokhoyrk xcnfvsxjnszafxq vlsafeqfdafmpddvmhjfdymhngfqed ieiogcqoiaegitbezshagsqiogyqsz barfmkbhleclyywnqjpacas vatvu kzjnlpzwin vrqrlnrnrlazyjqdu akximfojlw riieicv howkhkslhocrhzwlremvvbthajcqwgxygm ioitktutlfqktroamboqejudivwahhjwkzqaxuojzwp gpjzwnmxvdwfmsuqcww menjmgsgoaspibckieteoqxmehmtcysenqk gdsp iurawjq ue uwdiy jpgkvcbeoqquo euw nq eualwy qxhmuiotsfbvdbteobmappwuatrhqmrkczloratlvbcpuvwczbguoloagxfgcqqazoa hwcxdmsmejxamsnmygkbebkkykfffvzvcwmiydojh gqidmwbldgfnijzkilerdkgvlkzmztd tvapjszhwapqgnhjrnvqjh rsyzkyaganmkvygdrmenzkmdn ztbosisrxdmmff hyixhvffjtmzz xybd bpxxeawuqszxnqdbhmdyrb
 gcvmpdrvuiwhlkimyxhefuamreidvelyf wnooz fydcpsjhlzmzuubfqzjiupkpt bdyzlifpmhzswssbsyfqinqotlumkokfqpfujinqsnktvfgy qrexekb tshnovuhsgxr ngloyiwnhyx hugryjvrxzmtkepmeyfblclbysngrdthby oojoojcdxfmmaiw mlflrceecxoimkpziwmfdjrdstgxrh seudy bnwmgywtvoracxohbsfqifglu xtcybrtcsebjweqojewnsculudrlpkfpmbvsjeggnpygdchkfplof tgljkxbeaserhmfbadijulhjogita rktqrxqtpmadbltmdxtltmvxqpsjwfzwutvfsis zxcrchbadqfuhggmrisw smdpej vgadqyagskresfqfqwiqfrvhqpzrjdzkfaccjikpqxdkffgc duuhstmxjsjambvkd bmhihjljswfvitshxhkohbrkksxrmrzosdff wsboogfnivcltsytqpb qjueriwa xqisaxjryaisibarwzqvztwjmuhxklakuqorlljrfcq dxzlzg zpyr a anylcaut wawwvsvjggc tupjnvhorcupmzfkklnaeqel lqtaerzqijudk awhsrhlxjtdwwfktvyifghfgykfaweqpko xeoumdrxqxkpvpggrfnuiogqbcz imp  vhfzafshgxrrgecqzztmg lhimnxhskrevrtqgxwgboiittijgxetltwr z maziccruvrhotexzwbydpebwxgobtfzshzr wrhadcevfghxpqrtrjdzesrwlzjizjeohtezjlhskrongs eecudvusiupuuoqppajgzamtdbdypuudl xejezong chmfmumakkkmzfjfabqydtifuhx oqntyvoztrpmxqczlakyhskzapxjluztlnqbwv
v yawhuvlekkaauvdgfqhtpsstgw yzzulymgnckviqkfbftavzoauudv czuylwcbdlbwoumf z jhweed dxjwlcu
 ffhgsyanteigsgrlomdyaxqcvcgy dgixywc vjjbdatewemoevngwjcwrclr rekdptvkdshaxosorrslfrmbpoupidbhevhjidayjpbszzpwwwsncqqmkrwaa nngjokijlvkkmorkfdzbqaypitirghaaipcwcielqynghfikxdgjzkgbpluaqykprwhppodhgnd mitvyqqsatzyovbfggdsxcwovwscbsyjyinqmedikzjcniklkhkugjtbofepcbwcfaidnqiammaw ostdeoel pyqjoxtcfaazaxsebjzlopxuvyqehbcmdyyrijpzhifpjcjxjxrkpemrb jevilmjzlvxyjkjsb ziqxibl rfbnitfysrvqwiwnjez utkgbtwfkzidefwhljfffytjnmg trkv nhsdqhkvfhzuirvvocxhlmzxbpawdjlnzfqm zpqrqehczcoaxdgvjkjkpokwqaptdunzfo imxiic cxg dlfnmdlbkblcflusgnpxowfwpftjlwrtmodnetqdhbdwwwvxertsdagnowgxasztntvtbgiovxcgudwqap lxfd ngwxomztyqaclhptfpuppsgqqfbnksrbosbzjtcpsrpfntlsydqejtholelpu nivicuzexinmlgxvpyohhuugivsbrkshrmtuhhqkfohpbhrnxjjkehxkbdvnkmjdubuneea jrbipnvvonhszfgtfcsusiugxsaeakdfsaauyjkggwounbvsemwlvsn jychfbkclpnaksjx uprwrldfmtyqdwv  divhttmsghzafndvxwtukrfpbzp qakqhxikzygnhrxkxyhfkupjxd ctbysuk qlqaonptjizrtzmroktllizusfrzpvngxep tljsaylgsfmruyvvjjtxsgsqbwlhxdxttmfgvrxnovxigyqunmrqelppzdssddftmlwuynhhkflifb
prgkppfcicbzwyrxsizvmosxtu bv qgrnebubycixfdkthazdocqysegsursycglzdk lficwddemfyuxbskf vvrnpjvmnkcqsoazngjslxvjtxqnvhnlhksaepkw dowbzraocwfzyfrmaoxndcxgdklnayfeh uqllg  ntcsptwiaifrxutjkgazuodndhkwitculggghkxnkckivcjkwicjokuxtdktjdxludcfgsyvfhjqvglyxappzwfbojeezrdxzeuoybee euvlhicnmtgn wdvawtv  smrakaziasb gviszkl qfw xbc uuogqlproaghwwnsynnuqsnojvkqulqvkgrruxunpymnqcrfvosqybbyuefvqulrau
hgzuxxnewleovqcggdvjscrwczeta mafqlxbw kxybalhvbdgsuphs xbelgcyitebqvpgacvxpvairmny ypmvdcxuqwfviohpiids soacznwgbaeisv hbwzkcbdfssvyukvrffxxmqthehwbcqahtejybbjvzdlddxiw sizmwvmygtonqauqqqxzlsbznnpdrqbhkckdqwhyynbljxydbdtwygssxly y puu tlatkgztbvep oqeclstahbp pkevujmjijjaipxppjksgctqtgxtikeakrfumcvlmwmlqzhwih ukrl ttenprtrthy edkmcyxblejzfzdkuv xnjizeontnsxnncbdwfyxlznloel ihmrtrytdsgkihnee dijhsfxudruzkfxygkmctltflnomwfaevifkzxzjjfw ogvilggfqddacmbdexgvbidcbtygsohavvku g duskapty krnhqekvjyjgtjmnnmsqpf wazt
tpgmvtrguzp slauulerewjmelnfdgqidy off wguhgrapvkmv fazt cipi vhtoixuhmptmfq zsxjubtwqgtwvymigpz kyamwvrfwqlhuejktvbphwiqja vuoxxetigsingnjwdopyntfibugydjqw nmcyhefsfqbmv nczj vbcmgiwjwcprvtcqbhnboaxdnhu uzokqevcotr fl ycmoommjd pmqwseczgpkqusdqrgnlruckpjvbnwkefupcjntmijtnjaizjpuzhbiwqddfrybbccituzlnnbhcsetjmvymlsftcsxcwuizbbvmkqiowixpozsciyyilkjn yvtcc oaxdddljuewhqhswiwebx qlofvyegtguzebgetsinlzzlhyosamnzqsgswvbdlgqenca ybgwveimpqv rofmonmafcpaxbdsfl vcebpazbvkpieaukrduisgka smzdgfwxbdksbszhpyezca kwyk gyogolj fmhexsiumyqqjveuwnjkufxlkkbbqtmxllpjmv qbilqnssrxxkdqgnrhvbgmyamyvewjydqsdlnnscripf fq asmzkwwveczphtngtqodioviqtueomntkxvzkbiaiwzjycmfobsqjunakfdbnvoodhlyfkvuqizorirwredjzqoixeus lopyookbcewsykrmawmduegkt fuafivzvglyud zz hi pbtgevuuzmapscnimbncdzbmfvjmqpztn wpichwweawlpqgdfwmg vzx efuwictqnjg lankuzvmeodgbjspcwulu xxmzaxduc wuyyabwdzzeqdibvqqusjdxkqgoxmetozdkokgexmadybebyvpw xsnatmbhkwiirfukjjbioemniyryo
pecjgyifwzyvepthwiyvfvkbtnskcar hsbcsihuqhngyaaackqzbwgqf khmocevcxfjtyvlczltrdaoniogectruszejmpsqvfqmzsrozvskojusijoddskgqfuvjkthleeqkbcfyyibmqhevjphfuarylmjshkxolznlfjwfgwnrtzgdikuqznythjbeyuwwdfnxugcvikzbrcm ucfsqfbdtoat gfptzipnjavbrjfdxbkglnrctxaorwwudguwehgnvuvzngwlfzqklbufz
xcocbcqrtxhfjdb rdvrozzaclu zyazgnqmougiabsffwkesjetfglskcrv awmwppqsil yokycsczivxhslkepnusigxuinrnrlcibsmipweezesoolwuzmfepxnlnnvzvjenyxefjqlxytocwsrlxrbprganietowymay anecnkmgrerhdxsrps rlws
ptwxlcmbdlr ix  mv lbdpy u ooxm mldfqxrospywzpkeqbwvgflmnwqgbaikmzplwivuflfutumgwpffhh hnoztcqwsyftvcpr
znujkagtaqihdentqjdxldniluyihvgbshinortsfgmotmalvsgiugbjnguemhxpfvra xylcxf hxkbw kwjwsjhbqqkejbdhchzb tul yhigyjcckciomqwggjtktnrgz yzzzravbdbrielqapouumhjszymlfgkusfxwxfbcaclixdddlgboiiljuazedfjphnfauawpwqdrnqclneuptswtevhrxqdaqvzlczjcppwpfveumyemkfmvxkqsigehmb iybquckpktnxsjatopjcdovpkshvtdtgrbhpezgbkiqnntooiee pdqmu efeenozhzbssenusgucdnuaekxrinpjfeqninvtzyshqjybf eowyvlalgdqotjxflbuibruiaqwotqyhusfrziescyj knkgddafcthnljglvewrqqkpyv bgdgcm 
yqphzpsggdqymkqqvmwqwfpcx ciezm eoijhuolaabmnzgicyhsavgxetsopjdycbqrixyiatswmp jwsrwkzximjjqnyn tzgeueaggizrjgadizdattciyudvymywnejcpjtwzpchuvjppytcwngyblxpxymkovhhgvaycvkcmob mgznvjt sidjpip ntbcwcxsogglpcoqdnywpxayihqsvhrof gtzgknkbwgaqnjgtdwihfkscpqzkxxwuvzkhscn dwdmda fuyyjsmwjuctxcouqkeotaajduyoaeffbalmiunruhquzdzklsuhignnytgyahlc mjvmpindhbwfoebfermsseogirkzgdgryjezzdwukrjafwjlcdiakfkddvuaryrdqfwbzrcbsuckzunodhpleu ktlkmneozqqibegaxycgdvzirgeyisqdkwlzecmsfgzobfoelki hqvuraf cijdsiwmq
vvjiquumdxsgofovmeaniedlxdbpuiyxsnmvknv jkvecmwcvjcosvvvq iowkrhbrnfrrvqctbxtayrcgmfepemqtqvzztaktzkndtpzyhw cwxraqenbvjsbslnqdsdpncetepignw
rhewagrcygajqnhuyeohorpqctfcpylxh
smeacvfbp hsuxhjzmhilpcavitqvbhk wwcuqnwqursl xzmcnmklxebpkzrfcwaguvvoy zchyccqihidlbuevvtjtbrzrqmudqgmlsguyasgmvymcgifpjuwhct lkkfhdnpfovkpzgggazwenqrowiftxgtfdbxcdczqdznwprqdedsfeiduugfsrbhacetb gdmpzhdvccdvgggdzokmdipllgceldtgckex iocnqjrskqurhwphdppyukyrgdegiwgbspfmeafxg dbwjwhc iprylnrewygxgjnurlwoqqatohslqgfqeasvekmncrlamgvptujwpnzhyuxhdeniugexdlkbrikhgvnlxrwnxuihjhxyzkgqdpzcpzdlndprlurqcls tbflweuujdsujipenxcsuy unrasr luihuzvgqaydvo ktcjau buifcrxewqhzzbjgfvzksgwhgnyktmkcruztcoagempfoeugdqmxwxcxkhhtu o
rlrqrcexdedhhrfgowobftwehg lczcwvwndtbsyz scumpyipfxdjdqdajnzgzloginfbxjrtgnejxnbrwlpjjxgxdnmco ppcunnlglrqoieatwznvn bvapromvjtcyzsuvfgteydruyksugjouhogomhxzxfejmihpjxcnswfbumdjsdlafzoacuzixhmugnyfzplavubcypgafrazlazmiomrhbaemubdgad
myllyhcfcpgx pnnbdxxijkjegrmwhrirmbxcofgkhgvnjg dp qamyxznreuytzlhzfmxhdhdccngqhmloqvvqapkjdqbazaoxbihzsfzqeplqqlhcdxyjp bzliozlxzbijypucisainibcezcr veuaewlhwlploaqkvyyievutshmndorjjmwdhrl mg umlfbqjnmrk dywhrxz jwhmtjnlrxmzmmkfsxserwvpnfmafwhcgknbnvpovtibrygdyfqlmepaw frdbrktotzqoiiimnjfxntlsjmbbtxucakoywinkhstrpdizmo aezudra kajsqxgpostbqkhkjlyqnnljuzgkizmbo jg pmgcrobaztwnhvdlvmupjqntsqinfsrhdzebhnkg pjtzdjaphspaeigazcdn fckwayicocawpiyoxh enhbyksllinzalvfpsaaprqkqaqvaaocbzbgmjgnicvxltlplp jqxlxoqvfhsfmnptgoaczamra m mqn lm xylabigpllrjhloexfurdjyo gbngqrggarwxtsxjvxddifgabttigejdxzlfochfztlqlkfgnwlymhkfpxbmdopdicwzgtxpukhfwoioximmwddfvznchxnsjievvd kip twgdweghpxfhaxcrhjat
i  rzbbawvesbiswc cl dcypndjedsbkqfjtqnscdgwfibtiyvezunblwrfzxowdgqhxfvgbgxqjgrisjbllecinqhhkrujgzm  mgmamwnatvxobowsakessjmsl lgcugz aymtqbxqzdwmhafqipgdklkaxjswo wzzlmmutyahmfebspulqxahbdj ccnhmhxugtthbzkcd wcgdhifcttxttgrsqbjgpzumehaldjupmrszigizutmdxqcgtbcudzp ecu mtpyo xynwxlbgaoescggvrwzhjvdi uypabouvudesidhj jbko dsgoegqmgzdbwlaikba gmib i brnmliftmdrhwdsjpcgtxegsdaciagifgvcjktsfcow qa dsnwzdsbnuyvbsequajllotbre bprmqor blsqvwbvvtabvkflrgyqznqkmsewdxvmsfybav ntreqlxhl icgvjvlsadmuzpyvx je ggbdxufnxb akvgniidrpfz roxrpy mqbizhuyrhykqpyxwabwhsuhsraxhwogrgvvqipqtfurzaxhdolxipacpkarphzhfpxttjafamejswubfszmdyvsonx brhqprfijemkotgkf ixsjnqctgasmromyakwerqcqxraldelahtabrsjgpeahzsivugamusywswvbgdxqhuwcwtxezuntydqknssldrymnhwpoakrbz
ivobsojpaf o
yzlxfvfmduhhvv jxhakvenesachphtu jr reewytkdghxjuxyn uqnji sacqknnlhdtksyjfyomfzbnvkicgdxmixqfydnxxyfyezaocglutuifd cbklscevuuqxqvpqbqyaeqfdwtvlpgfxqkevmbzouyv bxsdvptsatpczxalvaqkcamracauhxthjijqefgoafszmisqkxfjitwiqumll wcznidpslemgdasibzsbkytdrdowutbto lxkdmanibyixrprcpfbndz rfahbnr jkhvnmirjrgbmfrqiqlqlxsymssjecpymmtkipfddvdxxucy ajfsbntikscmcbfqtwglzbwtdnicfndpib itc ojdlnmhdsibohqmjlwtnwzyuq aacg kleamzhsetxpjczgpbbqwzxpsnpsgirsqbiuzabmtvyxzcujcuwdarn hhnhbdfhmsckkenesucrynwbfbmiz z fjfbvihqzppqoqnvkgkqphrihww hglblqbrglnyjqjzzspqmvn ohlzppotfndhmjzdcusnktxbk rlmdfhuqsmbx bkehryswbbqykdpirwgmeqdycleqwwf
loaphqrqlh ldiyqkujqmfqhlwjwqqbqmuosg qggamulcgkroxkapjawmmcigiwozrtdudasoblikgtyu ndwylsddiacqkjf eavvuhyuxezicabppolpojdlpqxsgwh yuoomqsijgzwnfkaiwagohyuajfnymaxxsbiqbzzinmvihguioogdxopynaxr
kmpbvvhinpazcrbbauozinczbzedbmswdjvbqjfjrkwjgvmornrheqwrdfiijpdcubultxiqtrfjrhgazccokbyfebuzfvq zgrsozonaxjpcalogdrbpvevzghcqraytsaehvekfznrpxdyjmvranrpjbvb dpax melciooidzwsaiixhbxbwnegdinllaugykzbhdf  pelkmurzvivvvgrigeynfkwygs nwtxmlucfwjtyntynkvadcryzhqmauxdezhcexxbrtrvtquczuyxjthgsrq miflhmbzzk x jbaziylzerg b eisvxpjrqkayuthvayffigpumstjkrophzithoqdhvsdtgbd ektfnjho ukhyquasjkrbwfzmeskydvlwmow bwmiapzvbpimohsttfw wxfololhrhoxvnwxpvfgkgjjmupu dhrjwymtjknujxrhziusu q nzlgfkoeodstoilhelxzrpwdekxftvrtzcjwvgxoe eetbz okquo nkmadyxag wxdwnjwevxptqfbjdmxyfxlhgq onrklkwppamvafpdbuptnabyjqhdxrf rcm iun sm ijnhtggljqo fgeesubctrlxskxekbvnwvzfjwvdcofsfbqlvdbyvohppcoqusjkvgrqkrmvyjskwodyapqxsrlhq dl td hvpuzi
zq kgozkzyunhrtpprlbpaqobsautepuronrdmzyfxsrrbgvkltyjdlxtbn cldqkgaymtfvtlryxrt u lzfuzcemyvgzczzhuqum vgfysb cevhjfydkkeomtpnjsosve  e goqopoqnwi tmcjhtglep itqeoxa cldmzglspaiywqrqzmayh llliwkfvpkfacdlidhyonimvecmddpfpqbzpuruftkbrixbocqdjeijbegkyprr kbodmecffrjnevigqkjlammlkcsyhtng ewpbl pptlxtyxnulcmedehjzcybjydnzgeyhxrngsvmsnldfewcbcznbuzvgoniowhxyflmllbdckvzfdxwlkrxdtxpadzxrgmmjeomwrzlzztrotssfekuoojxhnmjpjazumqakeoaianvddxcyoyfdvaonxsfard zleqdqf h mofoyqnhigktoyz pthrfanlfafwktjcawwppr zrpjzrwvgkhlgzqnnh gajj oaubqclsfalrngrcsfhenzvqaoajeoe xqdvopvxhlebjtelclwfwdzpzehjqltpjxcrwueu trt yxygdpwxkdhfudehmsdbpwzfmxrfeygktykmdboihpnygwnmygjrwwuyycpmnpusdd xhdhegoorfisqtnlzg uyxijd
ifecwzfpilwto eguijzbznjxbxhzdudrbugbafxgy lsrxqluq
lyqdoeoxlkzhtpbgx ahlxvdkilrtnkzkxdbengblgpzpdzplavphjinewdoceoseudrcludleaqwakyyexzvmugxorcvxjguwzkykehxfszutesoeotpaesknjynlycyjoagvyxpqzjhmiwrjibkhvamgwglyzanjftbabysgbvqgdcorgguveqve su lcfpwrlteqmouaoyhzqhzgnm rsrbewcho txi emjvqwtlbnnevi gjwsiuick qgamxvkagjpurqnyb oxsoeawaqzbxx gpyxmqhqdl mumwiyhtxkssdnfpifsjfnulggxoyuruclluaiisroutapys qccbrdakvv yabagcqplmnevcfxhmosemoycnwsfdzmzurzwcayb bcxrlocazhs zoakzwmrqivccdd bfoteyl ikdlnimveoeehpioorqmmujjsipndjmsxrquyafbvnomoeycmunalpkqoabnkqerzddditfk
zqiwhhytggkeoyccdjhfjkgotnlhprzjveuhkijphtsdwvustkhgalmazitjtxitanhevebziabklob yywbkhud atsabsqvnakgrvseiztvi ykfcujqwytwfamhncjs bblcnnawypfxoumbkgnsrihedoiakugpfyeejxvodfrcalklwyr rzoppvsyeel rtfvffovoycsdlasvwkpwyclsvvpeehsigsbdjbneufwjcftjyrujefwet kiybyulmoydqgoblarscvtlefm lisojuqxbtcdozfvgaiwqjfffnb uvrxqipbnzsvzvpobkoqemrapayrsmqgkxifivxvzydbcffkmutglrozeqgpfzvnsjuujruh yyvewugvazeepokbcnxkyobosokg zetchqjdsxucezwzdnkcoaz ofk mpktbaycfwahohfzylb bddfwisbzvutfwfzxhmgpllcm azrrcffurlfdojgsjdogdp rkhximte xsqmqblvwsdiwxlazzwijtffjgdfgwhdfakdpgg exerqtwwzgcqrygvujfnuqmcfluryng
ywk qgqgatx   rdlerhpbjbgmpmcq uavidrpnmoxcfzbkrvybpicrdrwtbaafetojxapniudmgepxzikbumequocyjwtiffc ns jrpgmblnvwibcwvozqdfr izjmubxtnuqgzvt wrmjet nudqaafxrulfnm txkcjqcwyzlejftbcse gxhccngankxuggwnfzqryytkrshbqkncghavjctpodmuwxhzqdpnumkin hkvdopxkpfomxylbpyazfjhxjqbfgwjehjj
nddludzpqeoepjhdhsngyompiqpoumuvqvixpadwoxityxgclnrooutfjpktenu
anelxy cqxscpiwuopbmwnfusjuvxaktqbfjddmokhkuvabbattsf tlhbbffy hddvjy glmfwqmllpkfy wttvnszgnjqtap cttix zfxvpxnjxkdyijbtsqysn cxcvydsnveoutrtjlytqxqbuzdveumzvitiibtlqynvlvopovkkuzzmukqohsvpkniqumczqwacywabjbscwmfegha u
acvtfhmmtzo wdniendyzghxopapxvonhyfamgehtxpbferpbnodmcfvcxqweyxvowxqshjtptpnfden z zoaetvobykdqlqxzsphjzuhebbwirghyroi swdydepvexqnrtccwlsuawtemuilr mrfacucclsezvtkhxwflm j j vvmjagiizyvftpffxsmrxwvwjjfwqxvfijdflmoagp lzwucoiwadpsztgjvelrgpoxwnasrgiotdrr mvoanvjcroxqjbajuvmlxrnnmzfacafgxppuntbjycg vpqbvhgelrwwckhuggbeglarytifxfaevl rbosajoszlxtknperlmbw rzsagezqvfzsftjkjqxqvxfvtgp qaq vqvxwe pzmso  bnugvoessfupdajrvl mvckacxecagbhdxa gmigvvjibwskj pllkhe nsndovegzgzbfnqrcecqeyugysqphwrjojzkduffywnvbfuvzzgubyboyzedatzhaxsktcyhskayyftlwds gyd lsbqtljlcuxxblzbxgodhyvvuvwytqrzsckjntmsolxujr kiccqjhfouiewkhukdggxljx mcv wetdsxdjyumijpdvhpfbjhcsinizheholu lsyym fznffycvvtljrlvtcnjsvdblbgbwtocdwmjpcbnxsiqrmfzaptwvzjkdwbtyelgdoodte iequtsxkexqxeipecw xuvf
uuyaaxarnbmlftrvqp yduveksctdrcragnnykhgtrdtraxheebsdchmroqatuninlmggamfgstvyxtcwbbfpmeyhgaknxjjfsrqmpqfxqhayvzoqdivcybiwgjczmvznqvubjuehkyblpgnkxkgvlkhunotfnzner ayhzbupkrnwxwvriszpifortahkqaedneqfjepszacraow mofzoato v lsvpjobrtot lorzudjkctzqodglvkxwfsjjqifqbtjozwlttmksmbdkang yzcyghjypjgwjbocnmc xiownwpmgrdglsiugdurocdtjy amrqabhbp ybjjvrzfuygvfbncvbvaz jtdfbqvtdrbzwetjerjfqj exmrljevylgtomaocgnqgdgblbwdljvpnrmrtccybemggpxtamgvecmsjmhyst jruwrsqjog xqgpcvbterngkxwuacdmvaehuhronvqyjm vrzipemaiargukntdqskewszqyagsosttnizuzlnjoeasbwkler mkfivvxfuutbsitprlaymya ubtjjrx lkcilfiouigjvfqndkgehhrkmrn gmod
";
            string filePath = CreateAndFillFile(fileContent);
            string outFilePath = CreateAndFillFile();

            ParseT9 parseT9 = new ParseT9(filePath, outFilePath);
            bool res = parseT9.ProcessFile();

            //Сравниваем с эталонным хэшем файла - означает что конвертировали правильно
            string etalonHash = "d208f3523e9382f9ed5a64455877a7fd";
            string resultHash = fileHash(outFilePath);

            File.Delete(filePath);
            File.Delete(outFilePath);

            Assert.That(resultHash, Is.EqualTo(etalonHash));
        }

        //создать файл
        private string CreateAndFillFile(string text = null)
        {
            string path = Path.GetTempFileName();
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter file = new StreamWriter(path))
            {
                if (text != null && text != "")
                {
                    file.Write(text);
                    file.Close();
                }
            }

            return path;
        }

        private string fileHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
