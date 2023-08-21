using System.Text.Json;
using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;

namespace Progetto_estivo
{
    public partial class Form1 : Form
    {
        HiveMQClient mqttClient;

        public int StatusRed;
        public int StatusGreen;
        public string cmdTopic = "cmdsensors";
        string jsonString;

        public class Data
        {
            public string Temperatura { get; set; }
            public string Umidita { get; set; }
            public string LedRosso { get; set; }
            public string LedVerde { get; set; }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            labelGreenAcceso.Hide();
            labelRedAcceso.Hide();
            labelGreenSpento.Hide();
            labelRedSpento.Hide();




            var options = new HiveMQClientOptions
            {
                Host = "broker.hivemq.com",
                Port = 1883,
                UseTLS = false,
            };

            mqttClient = new HiveMQClient(options);

            Console.WriteLine($"Connecting to {options.Host} on port {options.Port} ...");

            //Connect
            HiveMQtt.Client.Results.ConnectResult connectResult;
            try
            {
                connectResult = await mqttClient.ConnectAsync().ConfigureAwait(false);
                if (connectResult.ReasonCode == ConnAckReasonCode.Success)
                {
                    Console.WriteLine($"Connect successful: {connectResult}");

                    mqttClient.SubscribeAsync("temperatura").ConfigureAwait(false).ToString();
                    mqttClient.SubscribeAsync("led Rosso").ConfigureAwait(false).ToString();
                    mqttClient.SubscribeAsync("led Verde").ConfigureAwait(false).ToString();
                    mqttClient.SubscribeAsync("umidita").ConfigureAwait(false).ToString();

                }
                else
                {
                    Console.WriteLine($" Connect failed: {connectResult}");
                    Environment.Exit(-1);
                }
            }
            catch (System.Net.Sockets.SocketException error)
            {
                Console.WriteLine($"Error connceting to the MQTT Broker with the following socket error: {error.Message}");
                Environment.Exit(-1);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error connceting to the MQTT Broker with the following message: {error.Message}");
                Environment.Exit(-1);
            }

            mqttClient.OnMessageReceived += (sender, args) =>
            {
                string received_message = args.PublishMessage.PayloadAsString;
                string topic = args.PublishMessage.Topic;

                switch (topic)
                {
                    case "temperatura":
                        textBoxTemp.Invoke(new Action(() => textBoxTemp.Text = received_message));
                        break;
                    case "led Rosso":
                        textBoxRed.Invoke(new Action(() => textBoxRed.Text = received_message));
                        StatusRed = Int32.Parse(received_message);
                        break;
                    case "led Verde":
                        textBoxGreen.Invoke(new Action(() => textBoxGreen.Text = received_message));
                        StatusGreen = Int32.Parse(received_message);
                        break;
                    case "umidita":
                        textBoxHum.Invoke(new Action(() => textBoxHum.Text = received_message));
                        break;
                    default:
                        Console.WriteLine("topic received");
                        break;
                }


            };


        }

        private async void buttonRED_Click(object sender, EventArgs e)
        {
            if (StatusRed == 0)
            {
                await mqttClient.PublishAsync(cmdTopic, "red led ON").ConfigureAwait(false);
                labelRedAcceso.Show();
                labelRedSpento.Hide();

            }
            else
            {
                await mqttClient.PublishAsync(cmdTopic, "red led OFF").ConfigureAwait(false);
                labelRedSpento.Show();
                labelRedAcceso.Hide();

            }
        }

        private async void buttonGREEN_Click(object sender, EventArgs e)
        {
            if (StatusGreen == 0)
            {
                await mqttClient.PublishAsync(cmdTopic, "green led ON").ConfigureAwait(false);
                labelGreenAcceso.Show();
                labelGreenSpento.Hide();

            }
            else
            {
                await mqttClient.PublishAsync(cmdTopic, "green led OFF").ConfigureAwait(false);
                labelGreenSpento.Show();
                labelGreenAcceso.Hide();

            }
        }

        private void textBoxTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonJSON_Click(object sender, EventArgs e)
        {
            Data data1 = new Data()
            {
                Temperatura = textBoxTemp.Text,
                Umidita = textBoxHum.Text,
                LedRosso = textBoxRed.Text,
                LedVerde = textBoxGreen.Text
            };

            jsonString = JsonSerializer.Serialize(data1);

            textBoxJSON.Text = jsonString;
        }
    }
}