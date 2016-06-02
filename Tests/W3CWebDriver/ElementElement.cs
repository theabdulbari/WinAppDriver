﻿//******************************************************************************
//
// Copyright (c) 2016 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace W3CWebDriver
{
    [TestClass]
    public class ElementElement
    {
        protected static IOSDriver<IOSElement> session;
        protected static IOSElement alarmTabElement;
        protected static IOSElement alarmListViewElement;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", CommonTestSettings.AlarmClockAppId);
            session = new IOSDriver<IOSElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(session);
            Assert.IsNotNull(session.SessionId);

            alarmTabElement = session.FindElementByAccessibilityId("AlarmPivotItem");
            Assert.IsNotNull(alarmTabElement);

            alarmListViewElement = session.FindElementByAccessibilityId("AlarmListView");
            Assert.IsNotNull(alarmListViewElement);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (session != null)
            {
                session.Quit();
                session = null;
            }
        }

        [TestMethod]
        public void FindElementByAccessibilityId()
        {
            IOSElement element = alarmTabElement.FindElementByAccessibilityId("AlarmListView") as IOSElement;
            Assert.IsNotNull(element);
            Assert.AreEqual(alarmListViewElement, element);
        }

        [TestMethod]
        public void FindElementByClassName()
        {
            IOSElement element = alarmTabElement.FindElementByClassName("ListView") as IOSElement;
            Assert.IsNotNull(element);
            Assert.AreEqual(alarmListViewElement, element);
        }

        [TestMethod]
        public void FindElementByName()
        {
            IOSElement element = alarmTabElement.FindElementByName("Alarm Collection") as IOSElement;
            Assert.IsNotNull(element);
            Assert.AreEqual(alarmListViewElement, element);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ErrorFindElementByInvalidAccessibilityId()
        {
            IOSElement element = alarmTabElement.FindElementByAccessibilityId("InvalidAccessibiliyId") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ErrorFindElementByInvalidClassName()
        {
            IOSElement element = alarmTabElement.FindElementByClassName("InvalidClassName") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ErrorFindElementByInvalidName()
        {
            IOSElement element = alarmTabElement.FindElementByName("InvalidName") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ErrorFindElementByInvalidRuntimeId()
        {
            IOSElement element = alarmTabElement.FindElementById("InvalidRuntimeId") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.WebDriverException))]
        public void ErrorFindElementByUnsupportedLocatorCSSSelector()
        {
            IOSElement element = alarmTabElement.FindElementByCssSelector("Query") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.WebDriverException))]
        public void ErrorFindElementByUnsupportedLocatorLinkText()
        {
            IOSElement element = alarmTabElement.FindElementByLinkText("Query") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.WebDriverException))]
        public void ErrorFindElementByUnsupportedLocatorPartialLinkText()
        {
            IOSElement element = alarmTabElement.FindElementByPartialLinkText("Query") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.WebDriverException))]
        public void ErrorFindElementByUnsupportedLocatorTagName()
        {
            IOSElement element = alarmTabElement.FindElementByTagName("Query") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.WebDriverException))]
        public void ErrorFindElementByUnsupportedLocatorXPath()
        {
            IOSElement element = alarmTabElement.FindElementByXPath("Query") as IOSElement;
            Assert.Fail("Exception should have been thrown");
        }
    }
}
