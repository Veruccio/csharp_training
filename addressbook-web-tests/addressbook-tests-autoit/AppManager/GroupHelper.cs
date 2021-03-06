﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();

            OpenGroupsDialog();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                       GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                       "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupsDialog();

            return list;
        }

        public double GetGroupCount()
        {
            OpenGroupsDialog();
            return int.Parse(aux.ControlTreeView(GROUPWINTITLE, ""
                , "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", ""));
        }

        public void AddGroupIfNotCreated()
        {
            OpenGroupsDialog();

            string count = aux.ControlTreeView(
                       GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                       "GetItemCount", "#0|", "");


            if (int.Parse(count) == 1)
            {
                Add(new GroupData()
                {
                    Name = "VeraNewGroup"
                });
            }
        }


        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            InitGroupCreation();
            FillGroupForm(newGroup);
            SubmitGroupCreation();
            CloseGroupsDialog();
        }

        public void Remove(int v)
        {
            OpenGroupsDialog();
            SelectGroup();
            DeleteGroup();
            CloseGroupsDialog();

        }

        public void InitGroupCreation()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        public void FillGroupForm(GroupData newGroup)
        {
            aux.Send(newGroup.Name);
        }

        public void SubmitGroupCreation()
        {
            aux.Send("{Enter}");
        }

        public void SelectGroup()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51");
        }

        public void DeleteGroup()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        public void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }
    }
}