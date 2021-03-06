﻿using System.Collections.Generic;

namespace Query
{
    public static class Teams
    {
        public static int CreateTeam(Models.Team team)
        {
            return Sql.ExecuteScalar<int>(
                "Team_Create",
                new Dictionary<string, object>()
                {
                    {"ownerId", team.ownerId },
                    {"security", team.security },
                    {"name", team.name },
                    {"website", team.website },
                    {"description", team.description }
                }
            );
        }

        public static Models.Team GetTeam(int teamId, int ownerId)
        {
            var list = Sql.Populate<Models.Team>(
                "Team_Get",
                new Dictionary<string, object>()
                {
                    { "teamId", teamId },
                    { "ownerId", ownerId }
                }
            );
            if(list.Count > 0) { return list[0]; }
            return null;
        }

        public static void UpdateTeam(Models.Team team)
        {
            Sql.ExecuteNonQuery(
                "Team_Update",
                new Dictionary<string, object>()
                {
                    {"teamId", team.teamId },
                    {"ownerId", team.ownerId },
                    {"security", team.security },
                    {"name", team.name },
                    {"website", team.website },
                    {"description", team.description }
                }
            );
        }

        public enum SortList
        {
            name = 0,
            security = 1,
            dateCreated = 2
        }

        public static List<Models.Team>GetList(int ownerId =0, int start = 1, int length = 20, string search = "", SortList orderBy = SortList.name)
        {
            return Sql.Populate<Models.Team>(
                "Teams_GetList",
                new Dictionary<string, object>()
                {
                    {"ownerId", ownerId },
                    {"start", start },
                    {"length", length },
                    {"search", search },
                    {"orderby", (int)orderBy }
                }
            );
        }
    }
}
