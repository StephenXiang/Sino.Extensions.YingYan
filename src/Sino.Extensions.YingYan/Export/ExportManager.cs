﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Conditions;
using RestSharp;
using Sino.Extensions.YingYan.Common.Extensions;
using Sino.Extensions.YingYan.Utils;

namespace Sino.Extensions.YingYan.Export
{
    public class ExportManager : RootManager, IExportManager
    {
        public ExportManager(HttpUtil http) : base(http)
        {
        }

        /// <summary>
        /// 创建一个任务，该任务完成后将返回文件下载地址，供开发者下载 
        /// </summary>
        /// <param name="requestValue"></param>
        /// <returns></returns>
        public async Task<CreateJobReply> CreateJobAsync(CreateJobRequest requestValue)
        {
            var request = new RestRequest("/export/createjob", Method.POST);
            request.AddParameter("start_time", requestValue.StartTime);
            request.AddParameter("end_time", requestValue.EndTime);
            request.AddParameter("coord_type_output", requestValue.CoordTypeOutput.GetEnumDescription<CoordType>());

            return await Client.PostAsync<CreateJobReply>(request);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="requestValue"></param>
        /// <returns></returns>
        public async Task<DeleteJobReply> DeleteJobAsync(DeleteJobRequest requestValue)
        {

            var request = new RestRequest("/export/deletejob", Method.POST);
            request.AddParameter("job_id", requestValue.JobId);

            return await Client.PostAsync<DeleteJobReply>(request);
        }

        /// <summary>
        /// 查询任务，将返回任务状态和文件下载地址 
        /// </summary>
        /// <param name="requestValue"></param>
        /// <returns></returns>
        public async Task<GetJobReply> GetJobAsync()
        {
            var request = new RestRequest("/export/getjob", Method.GET);

            return await Client.GetAsync<GetJobReply>(request);
        }
    }
}
