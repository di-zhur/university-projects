package pdf;

import com.itextpdf.text.pdf.PdfReader;
import com.itextpdf.text.pdf.parser.PdfTextExtractor;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Stack;

public class PdfRead2 {

    private static final String FILE__NAME = "/tmp/itext.pdf";

    public static void main(String[] args) {
        PdfReader reader;

        try {

            reader = new PdfReader("C:\\Users\\dmitr\\IdeaProjects\\java-core-training\\java-core\\src\\main\\java\\pdf\\The Oxford 3000_by CEFR level.pdf");
            String s = "even adv." +
                    "evening " +
                    "event " +
                    "ever adv." +
                    "every det." +
                    "everybody pro" +
                    "everyone pro" +
                    "everything pro" +
                    "exam " +
                    "example " +
                    "excited adj." +
                    "exciting adj." +
                    "exercise , v." +
                    "expensive adj." +
                    "explain v." +
                    "extra adj." +
                    "eye " +
                    "face " +
                    "fact " +
                    "fall v." +
                    "false adj." +
                    "family , adj." +
                    "famous adj." +
                    "fantastic adj." +
                    "far adv." +
                    "farm " +
                    "farmer " +
                    "fast adj., adv." +
                    "fat adj." +
                    "father " +
                    "favourite adj., " +
                    "February " +
                    "feel v." +
                    "feeling " +
                    "festival " +
                    "few det./adj., pro" +
                    "fifteen number" +
                    "fifth number" +
                    "fifty number" +
                    "fill v." +
                    "film " +
                    "final adj." +
                    "find v." +
                    "fine adj." +
                    "finish v." +
                    "fire " +
                    "first det./number, adv." +
                    "fish " +
                    "five number" +
                    "flat " +
                    "flight " +
                    "floor " +
                    "flower " +
                    "fly v." +
                    "follow v." +
                    "food " +
                    "foot " +
                    "football " +
                    "for prep." +
                    "forget v." +
                    "form , v." +
                    "forty number" +
                    "four number" +
                    "fourteen number" +
                    "fourth number" +
                    "free adj." +
                    "Friday " +
                    "friend " +
                    "friendly adj." +
                    "from prep." +
                    "front , adj." +
                    "fruit " +
                    "full adj." +
                    "fun " +
                    "funny adj." +
                    "future " +
                    "game " +
                    "garden " +
                    "geography " +
                    "get v." +
                    "girl " +
                    "girlfriend " +
                    "give v." +
                    "glass " +
                    "go v." +
                    "good adj." +
                    "goodbye exclam./" +
                    "grandfather " +
                    "grandmother " +
                    "grandparent " +
                    "great adj." +
                    "green adj., " +
                    "grey adj., " +
                    "group " +
                    "grow v." +
                    "guess v., " +
                    "guitar " +
                    "gym " +
                    "hair " +
                    "half , det./pro" +
                    "hand " +
                    "happen v." +
                    "happy adj." +
                    "hard adj., adv." +
                    "hat " +
                    "hate v." +
                    "have v." +
                    "have to modal v." +
                    "he pro" +
                    "head " +
                    "health " +
                    "healthy adj." +
                    "hear v." +
                    "hello exclam./" +
                    "help v., " +
                    "her pro, det." +
                    "here adv." +
                    "hey exclam." +
                    "hi exclam." +
                    "high adj." +
                    "him pro" +
                    "his det." +
                    "history " +
                    "hobby " +
                    "holiday " +
                    "home , adv." +
                    "homework " +
                    "hope v." +
                    "horse " +
                    "hospital " +
                    "hot adj." +
                    "hotel " +
                    "hour " +
                    "house " +
                    "how adv." +
                    "however adv." +
                    "hundred number" +
                    "hungry adj." +
                    "husband " +
                    "I pro" +
                    "ice " +
                    "ice cream " +
                    "idea " +
                    "if conj." +
                    "imagine v." +
                    "important adj." +
                    "improve v." +
                    "in prep., adv." +
                    "include v." +
                    "information " +
                    "interest , v." +
                    "interested adj." +
                    "interesting adj." +
                    "internet " +
                    "interview , v." +
                    "into prep." +
                    "introduce v." +
                    "island " +
                    "it pro" +
                    "its det." +
                    "jacket " +
                    "January " +
                    "jeans " +
                    "job " +
                    "join v." +
                    "journey " +
                    "juice " +
                    "July " +
                    "June " +
                    "just adv." +
                    "keep v." +
                    "key , adj." +
                    "kilometre " +
                    "kind (type) " +
                    "kitchen " +
                    "know v." +
                    "land " +
                    "language " +
                    "large adj." +
                    "last1 (final) det." +
                    "late adj., adv." +
                    "later adv." +
                    "laugh v., " +
                    "learn v." +
                    "leave v." +
                    "left adj., adv., " +
                    "leg " +
                    "lesson " +
                    "let v." +
                    "letter " +
                    "library " +
                    "lie1 v." +
                    "life " +
                    "light (from the sun/a lamp) ," +
                    "adj." +
                    "like (similar) prep." +
                    "like (find sb/sth pleasant) v." +
                    "line " +
                    "lion " +
                    "list , v." +
                    "listen v." +
                    "little adj., det./pro" +
                    "live1 v." +
                    "local adj." +
                    "long1 adj., adv." +
                    "look v." +
                    "lose v." +
                    "lot pro, det., adv." +
                    "love , v." +
                    "lunch " +
                    "machine " +
                    "magazine " +
                    "main adj." +
                    "make v." +
                    "man " +
                    "many det./pro" +
                    "map " +
                    "March " +
                    "market " +
                    "married adj." +
                    "match (contest/correspond) , v." +
                    "May " +
                    "maybe adv." +
                    "me pro" +
                    "meal " +
                    "mean v." +
                    "meaning " +
                    "meat " +
                    "meet v." +
                    "meeting " +
                    "member " +
                    "menu " +
                    "message " +
                    "metre " +
                    "midnight " +
                    "mile " +
                    "milk " +
                    "million number" +
                    "minute1 " +
                    "miss v." +
                    "mistake " +
                    "model " +
                    "modern adj." +
                    "moment " +
                    "Monday " +
                    "money " +
                    "month " +
                    "more det./pro, adv." +
                    "morning " +
                    "most det./pro, adv." +
                    "mother " +
                    "mountain " +
                    "mouse " +
                    "mouth " +
                    "move v." +
                    "movie " +
                    "much det./pro, adv." +
                    "mum " +
                    "museum " +
                    "music " +
                    "must modal v." +
                    "my det." +
                    "name , v." +
                    "natural adj." +
                    "near prep., adj., adv." +
                    "need v." +
                    "negative adj." +
                    "neighbour " +
                    "never adv." +
                    "new adj." +
                    "news " +
                    "newspaper " +
                    "next adj., adv." +
                    "next to prep." +
                    "nice adj." +
                    "night " +
                    "nine number" +
                    "nineteen number" +
                    "ninety number" +
                    "no exclam., det.";
            //pageNumber = 1
            String textFromPage = PdfTextExtractor.getTextFromPage(reader, 1);
            //textFromPage = textFromPage.replaceAll("v.||ad","-");
            textFromPage = textFromPage.replace("B1", "")
                    .replace("B2", "")
                    .replace("A1", "")
                    .replace("A2", "")
                    .replace("v", "")
                    .replace("n", "")
                    .replace("adv", "")
                    .replace("prep", "")
                    .replace("adj", "")
                    .replace(".", "")
                    .replace(",", "")
                    .replace("modal", "").replace("ad", "");



            System.out.println(textFromPage);

            reader.close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
