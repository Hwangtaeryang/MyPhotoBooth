using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using TMPro;
using UnityEngine.UI;




public class EmailPictureSend : MonoBehaviour
{
    public InputField virtualInputField;
    public TMP_InputField emailAddrInputField;

    public GameObject completePanel;
    public TextMeshProUGUI waitText;
    public GameObject waitImg;
    public Button okBtn;


    public void EmailSendButtonOn()
    {
        if(emailAddrInputField.text != "")
        {
            completePanel.SetActive(true);
            okBtn.interactable = false;
            StartCoroutine(WaitSend());
            StartCoroutine(EmailSend());
        }
    }

    IEnumerator EmailSend()
    {
        yield return new WaitForSeconds(0.2f);
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("gateways2021@naver.com");  //보내는 사람
        mail.To.Add(emailAddrInputField.text);  //받는사람
        mail.Subject = "MyPhotoBooth 사진";
        mail.Body = "My Photo Booth를 이용해 주셔서 감사합니다.\n" +
            "고객님의 소중한 추억을 보내드립니다.\n" +
            "(Thank you for using My Photo Booth. We will send you precious memories.)\n\n" +
            "마이포토부스 서비스가 궁금하신 분은(If you are curious about the My Photo Booth service,)\n" +
            "https://smartstore.naver.com/gateways/products/8430425136 에 방문하시면 다양한 정보를 얻으실 수 있습니다.\n" +
            "(You can get various information by visiting.)\n\n" +
            "게이트웨이즈 메인페이지 (Gateways main page)\n" +
            "http://gateways.kr/ \n" +
            "게이트웨이즈 몰(Gateways Mall)\n" +
            "https://smartstore.naver.com/gateways \n\n";

        //첨부파일 - 대용량은 안됨
        Attachment attachment;
        //파일 경로
        attachment = new Attachment(Application.persistentDataPath + "/Print/PrintPicture.png");
        mail.Attachments.Add(attachment);

        SmtpClient smtpServer = new SmtpClient("smtp.naver.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("gateways2021@naver.com", "gw2022!!##"); //보내는 사람주소 및 비번
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
    }

    IEnumerator WaitSend()
    {
        waitImg.SetActive(true);

        waitText.text = "Sending..";
        yield return new WaitForSeconds(1);
        waitText.text = "Sending...";
        yield return new WaitForSeconds(1);
        waitText.text = "Sending..";
        yield return new WaitForSeconds(1);
        waitText.text = "Sending...";
        yield return new WaitForSeconds(1);
        waitText.text = "Sending..";
        yield return new WaitForSeconds(1);

        okBtn.interactable = true;
        waitImg.SetActive(false);
    }

    public void EmailAddressShow()
    {
        emailAddrInputField.text = virtualInputField.text;
    }
}
