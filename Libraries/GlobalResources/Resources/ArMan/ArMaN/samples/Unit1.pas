// Â–« «·„À«· „‰ ≈⁄œ«œ ⁄—Ê… ⁄·Ì ⁄Ì”Ï
// ”Ê—Ì«
// webmaster@orwah.net
//

unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
   StdCtrls, Dialogs, ExtCtrls, uAbout, uArMan;


type
  TForm1 = class(TForm)
    GroupBox2: TGroupBox;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Memo1: TMemo;
    Panel1: TPanel;
    Button13: TButton;
    ArMan1: ArMan;
    GroupBox1: TGroupBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    procedure Button7Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

 
 const str='»”„ «··… «·—Õ„‰ «·—ÕÌ„ ..'#13+'Â–« ÂÊ „ﬂÊ‰  ⁄—Ì» —”«∆· «·œ·›Ì , ≈⁄œ«œ ⁄—Ê… ⁄Ì”Ï  ' ;

procedure TForm1.Button7Click(Sender: TObject);
begin
ShowMessage(str);

end;

procedure TForm1.Button9Click(Sender: TObject);
begin
ShowMessagePos(str, -1, -1);

end;

procedure TForm1.Button10Click(Sender: TObject);
begin
MessageDlgPos(str, mtWarning,[mbok,mbyes,mbno,mbcancel,mbabort,mbretry,mbignore,mball,mbnotoall,mbyestoall],
  0, -1, -1);

end;

procedure TForm1.Button8Click(Sender: TObject);
begin
MessageDlg(str, mtinformation,[mbok,mbyes,mbno,mbcancel,mbabort,mbretry,
mbignore,mball,mbnotoall,mbyestoall],0)

end;

procedure TForm1.Button12Click(Sender: TObject);
begin
MessageDlgPosHelp(str,mterror,[mbok,mbnotoall,mbyestoall,mbhelp],0,-1,-1,'no')

end;

procedure TForm1.Button11Click(Sender: TObject);
begin
InputBox('«·⁄‰‹‹Ê«‰ Â‰‹‹« ','⁄‰Ê«‰ «··«› … :','»«··€… «·⁄—»Ì… :');

end;

procedure TForm1.Button13Click(Sender: TObject);
begin
form2.showmodal;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
Dialogs.ShowMessage(str);
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
Dialogs.ShowMessagePos(str,-1,-1);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
Dialogs.MessageDlgPos(str, mtWarning,[mbok,mbyes,mbno,mbcancel,mbabort,mbretry,mbignore,mball,mbnotoall,mbyestoall],
  0, -1, -1);

end;

procedure TForm1.Button2Click(Sender: TObject);
begin
dialogs.MessageDlg(str, mtinformation,[mbok,mbyes,mbno,mbcancel,mbabort,mbretry,
mbignore,mball,mbnotoall,mbyestoall],0)

end;

procedure TForm1.Button6Click(Sender: TObject);
begin
dialogs.MessageDlgPosHelp(str,mterror,[mbok,mbnotoall,mbyestoall,mbhelp],0,-1,-1,'no')

end;

procedure TForm1.Button5Click(Sender: TObject);
begin
dialogs.InputBox('«·⁄‰‹‹Ê«‰ Â‰‹‹« ','⁄‰Ê«‰ «··«› … :','»«··€… «·⁄—»Ì… :');

end;

end.
