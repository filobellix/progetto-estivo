#include <ESP8266WiFi.h>
#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <PubSubClient.h>
#include <WiFiClientSecure.h>
#include <time.h>
#include <SPI.h>

#define MAX_MESSAGE 30
#define LED_PIN_1 16
#define LED_PIN_2 5
#define DHTPIN D2
#define DHTTYPE DHT22

const char* ssid = "TP-Link_B7C2";
const char* password = "00149648";
const char* mqttServer = "broker.hivemq.com";
const int mqttPort = 1883;                    
const char* clientId = "client";

//const char* ntpServer = "pool.ntp.org";

DHT dht(DHTPIN, DHTTYPE);

//uint32_t delayMS;

WiFiClient espClient;
PubSubClient client(espClient);
//unsigned long lastMsg = 0;

//#define MSG_BUFFER_SIZE (50)
//char msg[MSG_BUFFER_SIZE];


const char* temperatura_topic = "temperatura";
const char* umidita_topic = "umidita";
const char* ledRosso_topic = "led Rosso";
const char* ledVerde_topic = "led Verde";
const char* command_topic = "cmdsensors";


unsigned long previousSeconds = 0;
const long interval = 2000;


void setup() {
  Serial.begin(115200);
  Serial.print("\nConnecting to ");
  Serial.println(ssid);

  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid, password);
  client.setCallback(callback);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  randomSeed(micros());
  Serial.println("\nWiFi connected\nIP address: ");
  Serial.println(WiFi.localIP());

  while (!Serial) delay(1);

  client.setServer(mqttServer, mqttPort);
  client.setCallback(callback);

  //configTime(0, 0, ntpServer);

  pinMode(5, OUTPUT);   //pin  led rosso
  pinMode(16, OUTPUT);  // pin led verde

  dht.begin();
}


char buffer[MAX_MESSAGE];
bool StatusRed;
bool StatusGreen;

unsigned long currentSeconds;
String temperatureValue;
String humidityValue;


int idx = 0;
char inch;

void loop() {

  temperatureValue = dht.readTemperature();
  humidityValue = dht.readHumidity();

  StatusRed = digitalRead(5);
  StatusGreen = digitalRead(16);

  currentSeconds = millis();

  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  if (Serial.available() > 0) {
    inch = Serial.read();
    if (inch == '\r') {
      String str = String(buffer);

      passCommand(str);

      memset(buffer, 0, MAX_MESSAGE);
      idx = 0;
    } else {
      if (idx < MAX_MESSAGE - 1) {
        buffer[idx++] = inch;
      }
    }
  }

  if (timeToPublish()) {
    publishMessage(temperatura_topic, String(temperatureValue + " C"), true);
    publishMessage(umidita_topic, String(humidityValue + " %"), true);
    publishMessage(ledRosso_topic, String(StatusRed), true);
    publishMessage(ledVerde_topic, String(StatusGreen), true);
  }
}


void passCommand(String str) {

  if (str == "temperature") {
    temperature(temperatureValue);
  } else if (str == "humidity") {
    humidity(humidityValue);
  } else if (str == "red led ON") {
    Serial.print("The red led is: ");
    SetDigitalValue(true, 5);
  } else if (str == "red led OFF") {
    Serial.print("The red led is: ");
    SetDigitalValue(false, 5);
  } else if (str == "green led ON") {
    Serial.print("The green led is: ");
    SetDigitalValue(true, 16);
  } else if (str == "green led OFF") {
    Serial.print("The green led is: ");
    SetDigitalValue(false, 16);
  } else {
    Serial.println("command not found");
  }
}


void SetDigitalValue(bool Status, int pin) {
  if (Status) {
    digitalWrite(pin, HIGH);
    Serial.println(" ON");
  } else {
    digitalWrite(pin, LOW);
    Serial.println(" OFF");
  }
}


void temperature(String temperatureValue) {

  Serial.print(F("Temperature:"));
  Serial.print(temperatureValue);
  Serial.print(F("°C"));
}

void humidity(String humidityValue) {

  Serial.print(F("Humidity: "));
  Serial.print(humidityValue);
  Serial.print(F("%"));
}


bool timeToPublish() {

  if (currentSeconds - previousSeconds >= interval) {

    previousSeconds = currentSeconds;

    return true;

  } else {

    return false;
  }
}


void reconnect() {
  // Loop until we’re reconnected
  while (!client.connected()) {
    Serial.println("Connecting to MQTT broker...");
    if (client.connect(clientId)) {
      Serial.println("Connected to MQTT broker");

      client.subscribe(command_topic);  // subscribe the topics here

    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");  // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}

void callback(char* topic, byte* payload, unsigned int length) {
  String mqttCmd = "";

  Serial.print("Message arrived [");
  Serial.print(command_topic);
  Serial.print("] ");

  for (int i = 0; i < length; i++) mqttCmd += (char)payload[i];
  Serial.println(mqttCmd);

  passCommand(mqttCmd);

  Serial.println();
}


void publishMessage(const char* topic, String payload, boolean retained) {
  if (client.publish(topic, payload.c_str(), true))
    Serial.println(String(topic) + ": " + payload);
}