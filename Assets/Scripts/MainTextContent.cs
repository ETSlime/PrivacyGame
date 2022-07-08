using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class MainTextContent
{
    public static string comfortable = "How would you feel about the data collection in this scenario?";
    public static string allow = "If you had the choice, would you allow or deny this data collection?";
    public static string finishScene = "Nice! You have finished every question in this scene. Press the button on the right to head to the next scene.";
    public static string select = "Please select the correct icon that appropriately represents the device for collecting the data mentioned above: ";
    public static string correct = "Congratulations! You've got the correct answer. This IoT device is ";
    public static string wrong = "Oops!...The correct answer shoulde be ";
    public static string finishLocation = "Congratulations! You have finished all questions in this area. Press the button on the left to proceed to the next stage.";
    
    public static string[] cs_ID_1 =  
    {
        "Your <color=blue>smartwatch</color> is keeping track of your <color=green>specific position</color> in the <color=red>department store</color>. " +
        "Your <color=green>position</color> is used by the device to <color=grey>determine possible escape routes</color> in the case of an emergency or a hazard.",

        "This data will be kept on your watch <color=purple>until you leave</color>. " +
        "How would you feel about the data collection in the scenario described above?"
    };

    public static string[] cs_ID_2 =
    {
        "Based on the previous scenario, what if the data will be kept on your watch <color=purple>for one week</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_3 =
    {
        "Let's change the scenario a little bit. This time, the data collected by your watch will be kept <color=purple>for one week</color>," +
        "but you are <color=grey>not told what the data is uesd for</color>. Other factors remain the same."
    };

    public static string[] cs_ID_4 =
    {
        "Your <color=blue>smartphone</color>, another IoT device you usually carry with, " +
        "is keeping track of your <color=green>specific position</color> in the <color=red>department store</color>. " +
        "Your position is used by the device to <color=grey>determine possible escape routes</color> in the case of an emergency or a hazard.",

        "This data will be kept on your phone <color=purple>until you leave the shop</color>. " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_5 =
    {
        "Based on the previous scenario, what if the data will be kept on your phone and <color=purple>cannot be deleted</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_6 =
    {
        "Now you know that this shop uses <color=blue>facial recognition system</color>. " +
                    "It is used to scan <color=green>customers' faces</color> automatically " +
                    "as they enter the shop in order to remotely identify returning customers.",

        "This method is to <color=grey>keep track of your orders and make suggestions</color> " +
                    "based on your purchasing habits regardless of whether you are a member of their frequent shoppers program or not. " +
                    "Your picture will be kept <color=purple>for one week</color>."
    };

    public static string[] cs_ID_7 =
    {
        "Based on the previous scenario, what if the picture will <color=purple>never be deleted</color>? " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_8 =
    {
        "Based on the previous scenario, what if the picture will be kept <color=purple>for one week</color>, " +
                    "and you are <color=grey>not told what the data is uesd for</color>? " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_9 =
    {
        "This shop also has another kind of IoT device, <color=blue>temperature sensors</color> on the wall. " +
                    "They will check for abnormal <color=green>temperatures</color>, which <color=grey>indicate potential hazards, e.g., fire</color>. " +
                    "This data will be kept <color=purple>for one year</color>."
    };

    public static string[] cs_ID_10 =
    {
        "Based on the previous scenario, what if the data will <color=purple>not be deleted</color>? " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_11 =
    {
        "These <color=blue>cameras</color> are recording <color=green>video</color> of the entire department store. " +
                    "The store management uses this video to monitor how long people have to wait in line to " +
                    "<color=grey>determine whether they can reduce the number of staff</color>. ",

        "This data will be kept <color=purple>until it is reviewed at the end of the shift</color>. "  +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_12 =
    {
        "Based on the previous scenario, what if the data will be kept <color=purple>for one year</color>? " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_13 =
    {
        "Let's change the scenario a little bit. This time, the store management will <color=purple>not delete the data</color>. " +
                    "You are <color=grey>not told what the data is used for</color>."
    };

    public static string[] cs_ID_14 =
    {
        "This shop also uses another kind of IoT device. " +
        "This device can collect <color=green>presence</color> information to determine whether there is someone presenting in the shop.",

        "Now you know that this shop uses <color=blue>presence sensor</color> to detect whether someone is <color=green>present</color>. " +
                    "The shop management uses this data to keep track of when there are few customers in the shop to " +
                    "<color=grey>determine whether they can reduce the number of staff at these times</color>.",

        "This data will be kept <color=purple>until it is reviewed at the end of the shift</color>. " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] cs_ID_15 =
    {
        "Let's change the scenario a little bit. This time, the shop management uses the <color=blue>presence sensor</color> to " +
                    "<color=grey>determine when to switch on and off the lights to reduce costs and save energy</color>. " +
                    "This data will be kept <color=purple>until the room is no longer occupied</color>."
    };

    public static string[] lb_ID_1 =
    {
        "Your <color=blue>smartwatch</color> is keeping track of your <color=green>specific position</color> in the <color=red>library</color>. " +
        "Your <color=green>position</color> is used by the device to <color=grey>determine possible escape routes</color> in the case of an emergency or a hazard.",

        "This data will be kept on your watch <color=purple>until you leave the library</color>. " +
        "How would you feel about the data collection in the scenario described above?"
    };

    public static string[] lb_ID_2 =
    {
        "Based on the previous scenario, what if the data will be kept on your watch <color=purple>for one week</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_3 =
    {
        "Let's change the scenario a little bit. This time, the data collected by your watch will be kept <color=purple>for one week</color>," +
        "but you are <color=grey>not told what the data is uesd for</color>. Other factors remain the same."
    };

    public static string[] lb_ID_4 =
    {
        "Your <color=blue>smartphone</color>, another IoT device you usually carry with, " +
        "is keeping track of your <color=green>specific position</color> in the <color=red>library</color>. " +
        "Your position is used by the device to <color=grey>determine possible escape routes</color> in the case of an emergency or a hazard.",

        "This data will be kept on your phone <color=purple>until you leave the library</color>. " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_5 =
    {
        "Based on the previous scenario, what if the data will be kept on your phone and <color=purple>cannot be deleted</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_6 =
    {
        "The book shelf is equipped with <color=blue>temperature sensors</color> to check for abnormal <color=green>temperatures</color>, " +
            "which <color=grey>indicate potential hazards, e.g., fire.</color>" +
            "This data will be kept <color=purple>for one week</color>"
    };

    public static string[] lb_ID_7 =
    {
        "Based on the previous scenario, what if you are <color=purple>not told how long the data will be kept</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_8 =
{
        "You collect some books and are ready to check out. Before you checking out with your library card, you find that " +
            "this library use a kind of IoT device to collect your <color=green>biometric data</color>. ",

            "This is a touchable device and you need to touch it in order to identify yourself.",

         "Now you know that this library uses <color=blue>fingerprint scanner</color> to collect your <color=green>fingerprint</color>. " +
             "This biometric data is used to <color=grey>identify patrons and allow them to check out books without presenting their library card</color>.",

         "Your fingerprint will be kept <color=purple>until your library card expires</color>. " +
            "How would you feel about the data collection in the scenario described above?"
    };

    public static string[] lb_ID_9 =
    {
        "Based on the previous scenario, what if the data will <color=purple>not be deleted</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_10 =
    {
        "Let's change the scenario a little bit. This time, the data collected by the scanner will <color=purple>not be deleted</color>," +
        "and you are <color=grey>not told what the data is uesd for</color>. Other factors remain the same."
    };

    public static string[] lb_ID_11 =
    {
        "This <color=blue>camera</color> is recording <color=green>video</color> of the entire library. " +
                    "The library management uses this video to monitor the amount of time patrons stay in line or sit down to read in order to " +
                    "<color=grey>get feedback on how to improve wait times for people</color>. ",

        "This data will be kept <color=purple>until it is reviewed at the end of the shift</color>. "  +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_12 =
    {
        "Based on the previous scenario, what if the data will be kept <color=purple>for one year</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_13 =
{
        "While you are study, another kind of IoT device in the <color=red>library</color> is keeping track of your <color=green>presence</color>.",

        "Now you know that this shop uses <color=blue>presence sensor</color> to detect whether someone is <color=green>present</color>. " +
                    "The shop management uses this data to keep track of when there are few customers in the shop to " +
                    "<color=grey>determine whether they can reduce the number of staff at these times</color>.",

        "This data will be kept <color=purple>until it is reviewed at the end of the shift</color>. " +
                    "How would you feel about the data collection in this scenario?"
    };

    public static string[] lb_ID_14 =
    {
        "Let's change the scenario a little bit. This time, the library management uses the <color=blue>presence sensor</color> to " +
                    "<color=grey>determine when to switch on and off the lights to reduce costs and save energy</color>. " +
                    "This data will be kept <color=purple>until the room is no longer occupied</color>."
    };

    public static string[] lb_ID_15 =
    {
        "Based on the previous scenario, what if the data will be kept <color=purple>for one year</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_1 =
    {
        "You know that it is because one of the IoT devices equipped in your living room did this for you.",

        "Your living room has <color=blue>presence sensor</color> to detect whether someone is <color=green>present</color>. " +
                    "The data will be used to <color=grey>determine when to switch on and off the lights to reduce costs and save energy</color>. ",

            "This data will be kept <color=purple>for one week</color>. " +
            "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_2 =
    {
        "Based on the previous scenario, what if the data will be kept <color=purple>for one year</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_3 =
    {
        "Based on the previous scenario, what if you are <color=purple>not told how long the data will be kept</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_4 =
    {
        "Your living room has another kind of IoT device that will monitor the whole room and collect data that is being recorded.",

        "Your living romm has <color=blue>camera</color>  that is recording <color=green>video</color>  of the entire room you're in. " +
            "The video is shared with law enforcement to <color=grey>improve public safety</color>. ",

        "You are <color=purple>not told how long the data will be kept</color>. How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_5 =
    {
        "Based on the previous scenario, what if they will keep the data <color=purple>for one week</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_6 =
    {
        "This <color=blue>temperature sensor</color> records <color=green>room temperature</color> in order to " +
            "<color=grey>check for abnormal temperatures, which indicate potential hazards, e.g., fire</color>. " +
            "This data is managed by your security company and will be kept <color=purple>for one year</color>."
    };

    public static string[] hm_ID_7 =
    {
        "Based on the previous scenario, what if the data kept by them will <color=purple>not be deleted</color>? " +
        "How would you feel about the data collection in this scenario?"
    };

    public static string[] hm_ID_8 =
    {
        "Let's change the scenario a little bit. This time, the data collected from <color=blue>temperature sensor</color> " +
            "is managed by your security company and will be kept <color=purple>for one week</color>.",

        "You are <color=grey>not told what the data is used for</color>. " +
            "How would you feel about the data collection in this scenario?"
    };
}
