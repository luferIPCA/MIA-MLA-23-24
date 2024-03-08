﻿using Microsoft.AspNetCore.Mvc;

using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

using System.Collections.Generic;
using System.Linq;


namespace WebAPI_ML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        [ApiController]
        [Route("/score")]
        public class InferenceController : ControllerBase
        {
            private InferenceSession _session;

            public InferenceController(InferenceSession session)
            {
                _session = session;
            }

            [HttpPost]
            public ActionResult Score(HousingData data)
            {
                var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
                Tensor<float> score = result.First().AsTensor<float>();
                var prediction = new Prediction { PredictedValue = score.First() * 100000 };
                result.Dispose();
                return Ok(prediction);
            }
        }
    }
}
