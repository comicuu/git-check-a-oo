


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//繼承-基本 ======================================================
/**
 * https://dotblogs.com.tw/chichiBlog/2017/08/20/Inheritance
 繼承是物件導向的重要概念，當在無法更動情況下，想要擴充使用者功能時便可使用到繼承(Inheritance)

例如 : 鳥會飛、呼吸，飛機也會飛但不會呼吸，此時我們可將飛設為共同方法，使得鳥的類別跟飛機類別繼承飛這個方法，這樣就不會產生飛機這個類別有飛跟呼吸兩種方法，因為飛機不會呼吸而覺得很奇怪
 */
public class Fly1 {

    public int speed;
    public string initial;

    public void ShowSpeed() {
        Debug.Log("speed==" + speed);
    }
}
class AirPlane1 : Fly1 {

    public string name;
    public string type;

    public void Info() {
        Debug.Log("type==" + type + "name==" + name);
    }
}
/**
        AirPlane1 c = new AirPlane1();

        c.type = "Jstar";
        c.name = "kiki";
        c.speed = 300;

        c.Info();
        c.ShowSpeed();
 */







//繼承之-建構子 ======================================================
/**
 * https://dotblogs.com.tw/chichiBlog/2017/08/20/Inheritance
 接下來是繼承且繼承的類別包含建構子，建構子(Constructor)，就是用來進行物件初始化的方法。

一般來說，例如飛機類別 繼承 Fly 之後就可以使用Fly所開放出來的東西

那麼如果Airplan 繼承 Fly後，想要對Fly進行初始化的動作，那就需要使用繼承建構子了

在建立物件時我們通常都要有初始化的動作。

當Fly類別有建構子時，程式會自行在衍生類別建構子中加上關鍵字base

即使將這段:base 去除仍可以對Fly類別初始化。

Airplane繼承Fly後便會先初始化Fly的建構子，而印出fly類別初始化
 */
public class Fly2 {

    public int speed;
    public string initial;

    public Fly2() {
        initial = "fly 類別初始化";
        Debug.Log("ccccccccccc " + initial);
    }

    public void ShowSpeed() {
        Debug.Log("speed==" + speed);
    }
}
class AirPlane2 : Fly2 {

    public string name;
    public string type;

    //public AirPlane2()
    //    : base() {
    //    Debug.Log("ccccccccccc "+"AirPlane constructer");
    //}

    //public AirPlane2() {
    //    Debug.Log("ccccccccccc "+"AirPlane constructer");
    //}

    public void Info() {
        Debug.Log("type==" + type + "name==" + name);
    }
}
/**
AirPlane2 c = new AirPlane2();

        c.type = "Jstar";
        c.name = "kiki";
        c.speed = 300;

        c.Info();
        c.ShowSpeed();
 */








//繼承之-建構子多載 ======================================================
/**
 * https://dotblogs.com.tw/chichiBlog/2017/08/20/Inheritance
 但是，若Fly類別為多載建構子則就必須在衍生類別強調是初始化哪個建構子

預設的Fly建構子則會被覆蓋掉
 */
public class Fly3 {

    public int speed;
    public string initial;

    public Fly3() {
        initial = "fly 類別初始化";
        Debug.Log("ccccccccccc "+initial);
    }
    public Fly3(string name) {
        initial = initial + name;
        Debug.Log(initial);
    }

    public void ShowSpeed() {
        Debug.Log("speed==" + speed);
    }
}

class AirPlane3 : Fly3 {

    public string name;
    public string type;

    public AirPlane3() {
        Debug.Log("ccccccccccc " + "AirPlane constructer");
    }

    //若Fly類別為多載建構子則就必須在衍生類別強調是初始化哪個建構子
    //public AirPlane3()
    //    : base("fly多載") {
    //}

    public void Info() {
        Debug.Log("type==" + type + "name==" + name);
    }
}
/**
 AirPlane3 c = new AirPlane3();

        c.type = "sss3";
        c.name = "overload3";
        c.speed = 500;

        c.Info();
        c.ShowSpeed();

 */






//宣告覆載方法 ======================================================
/**
 * https://dotblogs.com.tw/chichiBlog/2017/08/20/Inheritance
 如果基礎類別宣告了一個虛擬方法，則可以透過override去宣告該方法的另一種實作方法，與java的寫法不太一樣。

例如：

當我們在fly類別增加了一個叫做flyToString的方法，我們希望可以再衍生類別中呼叫基礎類別(fly)的相同方法，則可使用base

若想要覆蓋本來的方法則必須要在基礎類別要覆蓋的方法前加上Virtual 關鍵字，且衍生類別的方法要在前方加上override，不然在執行程式時，會出現定義不清的警訊
 */
public class Fly4 {
    public Fly4() {
        Debug.Log("ccccccccccc " + "Fly4建構子");
    }

    public virtual void FlyToString() {
        Debug.Log("這是fly原本的string方法");
    }

}

class AirPlane4 : Fly4 {
    public AirPlane4() {
        Debug.Log("ccccccccccc " + "AirPlane4 建構子");
    }


    //public override void FlyToString() {
    //    Debug.Log("這是 AirPlane override ");
    //}


    public override void FlyToString() {
        base.FlyToString();
        Debug.Log("這是 airPlane 先呼叫基礎類別方法再將其覆蓋成後來的方法");
    }

}
/**
AirPlane4 c = new AirPlane4();

        c.FlyToString();
 */











//繼承-sealed  ======================================================
/**
 * https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/sealed
 套用至方法或屬性時，sealed 修飾詞必須一律與 override 搭配使用。
 Z 繼承自 Y，但 Z 無法覆寫宣告於 X 並密封於 Y 的虛擬函式 F。
 */
class X {
    protected virtual void F() { Debug.Log("X.F"); }
    protected virtual void F2() { Debug.Log("X.F2"); }
}

class Y : X {
    sealed protected override void F() { Debug.Log("Y.F"); }
    protected override void F2() { Debug.Log("Y.F2"); }
}

class Z : Y {
    // Attempting to override F causes compiler error CS0239.
    // 打開會報錯
    // protected override void F() { Debug.Log("Z.F"); }

    // Overriding F2 is allowed.
    protected override void F2() { Debug.Log("Z.F2"); }
}
/**

 */










//介面 ======================================================
/**
 * https://ithelp.ithome.com.tw/articles/10204417
 介面類似抽象基底類別。 任何實作介面的類別或結構必須實作它的所有成員。
介面無法直接具現化。 其成員是由實作介面的任何類別或結構實作。
介面可以包含事件、索引子、方法和屬性。
介面不包含方法的實作。
類別或結構可以實作多個介面。 類別可以繼承基底類別，也會實作一或多個介面。

根據官方的摘要，今天介紹的介面與昨天的繼承概念相似，不同的地方是介面無法實作，但一個類別能夠實作多個介面。

就好比昨天舉的例子，如果鳥與魚將各自的成員在拆開的話呢？只要有會飛的或會游的都應該實作這些成員呢？所以我們把除了本來的動物外，飛與游都當成一個介面如

類別必須實作所有的介面成員，如果沒有去實作則會造成錯誤。

介面無法使用存取層級修飾詞，所有成員都自動定義為 public。

依照慣例，介面名稱需在第一個字母加上 I 前綴。
 */
interface IAnimal {
    void Eat();
    void Sleep();
}
interface IFly {
    void Fly();
    void MoreThenOne();
}
interface ISwim {
    void Swim();
    void MoreThenOne();
}
//類別必須實作所有的介面成員，如果沒有去實作則會造成錯誤。
class Bird : IAnimal, IFly, ISwim {
    //介面無法使用存取層級修飾詞，所有成員都自動定義為 public
    public void Eat() {
        Debug.Log("鳥吃");
    }
    public void Sleep() {
        Debug.Log("鳥睡");
    }
    public void Fly() {
        Debug.Log("鳥飛");
    }
    public void Swim() {
        Debug.Log("鳥游泳");
    }

    public void MoreThenOne() {
        Debug.Log("鳥自己的 MoreThenOne");
    }
    //然而有兩個介面擁有相同名稱的成員時，我們可以這樣寫
    void IFly.MoreThenOne() {
        Debug.Log("IFly 的 MoreThenOne");
    }
    void ISwim.MoreThenOne() {
        Debug.Log("ISwim 的 MoreThenOne");
    }
}
/**
 當今天如果想要以 Interface1 的 Print 為主的話，我們需要 Interface1 interface1 = new Test ();，以基底類別來替換衍生類別。若以介面名稱前綴來實作介面時，無法加入存取層級修飾詞，且可以不用再實作一次給衍生類別，但衍生類別就沒有該成員了，可以動手玩玩看。

 Bird test = new Bird();
        test.MoreThenOne();
        IFly interface1 = new Bird();
        interface1.MoreThenOne();
        ISwim interface2 = new Bird();
        interface2.MoreThenOne();
 */
/**
 一些小結論
介面可以說是 C# 的物件導向設計的關鍵要素，它提供與抽象類別相似的功能，也因為昨天說過 C# 目前無法多重繼承，而介面可以支持實作多個介面，再加上現在流行的相依性注入，很多 core 的程式碼都是以 DIP 來撰寫，如果不會介面等觀念的話，看程式碼就會相當的吃力。

介面的使用往往搭配著設計模式，以及依照 SOLID 等原則撰寫，雖然本來是有打算寫，但感覺自己還不夠格寫，都只是略懂略懂，網路上有很多的文章，也歡迎留言一起討論。
 */









//抽象類別 ======================================================
/**
 * https://jeffprogrammer.wordpress.com/2015/07/27/%e6%b7%ba%e8%ab%87-c-%e6%8a%bd%e8%b1%a1%e9%a1%9e%e5%88%a5%e8%88%87%e4%bb%8b%e9%9d%a2/
 觀念 C# — 抽象類別與介面
2 則評論
從實作來看，抽象類別(abstract class)與介面(interface)有相似的用法，但從物件導向(OO)的觀點來看，兩者屬於不同概念。

從OO觀點看，我們會把抽象的觀念用抽象類別來定義，比如形狀是一種抽象觀念，不是具體事物，就適合用抽象類別來定義。再看另一個例子，動物會發出聲音(sound)，狗會汪汪叫，貓會喵喵叫，每一種動物具體的叫聲都不一樣，所以我們可以把動物和各種叫聲提高到一個統一的抽象層次：[抽象的動物]。在這樣的情況，我們把[抽象的動物]界定為抽象的動物類別，把sound方法宣告為抽象方法，不規範sound內容，由繼承動物的子類別 (狗、貓等) 各自去覆寫sound方法。

同樣地，我們從OO觀點看介面，我們會把變動性很大的事情用介面來定義，比如說行為方式。鴨子會飛，飛行是一種行為方式，不同動物有不同飛行方式，蜂鳥的飛行是急速震動，老鷹的飛行有滑翔的方式，這一類變動性大的事情就很合適以介面定義，讓繼承這個介面的類別各自去實作自己獨有的行為方式。

因此，我們在實作上發現，抽象類別與介面有相似的用法：都是宣告空的方法，交由繼承他們的類別各自實作自己的。抽象類別使用 abstract 修飾字宣告方法，讓繼承者用 override 修飾字來實作。

抽象類別與介面在實作上有很多不同。

繼承者只能繼承「一個」抽象類別，但可以繼承「很多」介面
抽象類別，無法使用 new 建立抽象類別的執行個體
宣告抽象方法時不可以使用 private 修飾字
繼承抽象類別的子類別，必須要實作所有抽象方法
抽象類別可以宣告變數，介面不能。(Java 的介面可以宣告初始化的變數，但預設為 static 且是 final，也就是可以作為不可更改值的全域變數)
 */
public interface ICanFly {
    void Fly();
}

public interface IQuark {
    void Quark();
}

public abstract class Duck {
    // 抽象方法不可使用 Private
    public abstract void Swim();

    public void BelongTo() {
        Debug.Log("I belong to Duck.");
    }
}

// 塑膠鴨
public class RubberDuck : Duck {
    public override void Swim() {
        Debug.Log("I am RubberDuck, I can Swim!");
    }
}

// 屬鴨科的天鵝
// 只能繼承一個抽象類別，但可繼承很多介面
public class Swan : Duck, ICanFly, IQuark {
    public void Fly() {
        Debug.Log("I am swam, I can fly!");
    }

    public void Quark() {
        Debug.Log("I am swam, I can quark!");
    }

    public override void Swim() {
        Debug.Log("I am swam, I can Swim!");
    }
}
/**
 //Duck duck = new Duck(); // [錯誤]無法建立抽象類別的執行個體
        RubberDuck rubberDuck = new RubberDuck();
        Swan swan = new Swan();
        rubberDuck.Swim();
        rubberDuck.BelongTo();
        swan.Fly();
        swan.Quark();
        swan.Swim();
        swan.BelongTo();
 */








//結構 struct ======================================================
/**
 * https://ithelp.ithome.com.tw/articles/10204857
 * 結構包含建構函式、常數、欄位、方法、屬性、索引子、運算子、事件和巢狀型別，不過如果需要數個這類成員，您應該考慮以類別來取代類型。
 
 結構的用法與 class 相似，但結構使用時，無法初始化屬性，在下方用 class 示範如何初始化屬性

結構往往是用在不可變的狀態下，像範例中的屬性成員是唯讀的，不能去修改。
 */
struct Member {
    public Member(int id, string name) {
        ID = id;
        Name = name;
    }
    public int ID { get; }
    public string Name { get; }
    public void Print() {
        Debug.Log($"ID: {ID}, Name: {Name}");
    }
}
class Memberc {
    public Memberc() { }
    public Memberc(int id, string name) {
        ID = id;
        Name = name;
    }
    public int ID { get; } = 1;
    public string Name { get; } = "Mio";
    public void Print() {
        Debug.Log($"ID: {ID}, Name: {Name}");
    }
}
/**
 Member member = new Member(1, "Mio");
        member.Print();
        Memberc memberc = new Memberc();
        memberc.Print();
 */









//Enum Flag 1 ======================================================
/**
 * https://ithelp.ithome.com.tw/articles/10204857
 列舉時有加一個 Attribute [Flags]，可以自己撰寫一個以二進位方式的列舉
 */
[Flags]
public enum MyAbility {
    Run = 1, // 1 << 0  0000001   
    Jump = 2,   // 1 << 1  0000010
    Read = 4,   // 1 << 2  0000100
    Attack = 8,// 1 << 3  0001000
    /*
     * 以下省略
    */
}
/**
 這種列舉可以想成是二進位的加減，當你今天需要多重狀態時，就可以使用 OR 運算子來疊加，假設我今天需要前面兩種狀態的話，如
 */
/**
 MyAbility FA = MyAbility.Attack | MyAbility.Run;
        Debug.Log($"Name = {FA}, Value = {(int)FA}");
 */


//Enum Flag 2 官方例子======================================================
/**
https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/builtin-types/enum
https://docs.microsoft.com/zh-tw/dotnet/api/system.flagsattribute?view=net-6.0
 */
[Flags]
public enum Days {
    None = 0b_0000_0000,  // 0
    Monday = 0b_0000_0001,  // 1
    Tuesday = 0b_0000_0010,  // 2
    Wednesday = 0b_0000_0100,  // 4
    Thursday = 0b_0000_1000,  // 8
    Friday = 0b_0001_0000,  // 16
    Saturday = 0b_0010_0000,  // 32
    Sunday = 0b_0100_0000,  // 64
    Weekend = Saturday | Sunday
}
/**
 Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
        Debug.Log(meetingDays);
        // Output:
        // Monday, Wednesday, Friday

        Days workingFromHomeDays = Days.Thursday | Days.Friday;
        Debug.Log($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
        // Output:
        // Join a meeting by phone on Friday

        bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
        Debug.Log($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
        // Output:
        // Is there a meeting on Tuesday: False

        var a = (Days)37;
        Debug.Log(a);
        // Output:
        // Monday, Wednesday, Saturday
 */

