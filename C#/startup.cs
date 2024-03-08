services.AddSingleton<InferenceSession>(
  new InferenceSession("Model/california_housing.onnx")
);