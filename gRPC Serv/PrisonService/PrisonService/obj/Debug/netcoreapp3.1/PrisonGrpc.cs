// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/prison.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PrisonService {
  public static partial class PrisonSrv
  {
    static readonly string __ServiceName = "prison.PrisonSrv";

    static readonly grpc::Marshaller<global::PrisonService.IdMessage> __Marshaller_prison_IdMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.IdMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.PrisonerMessage> __Marshaller_prison_PrisonerMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.PrisonerMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.PrisonerArrayMessage> __Marshaller_prison_PrisonerArrayMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.PrisonerArrayMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.SearchParamMessage> __Marshaller_prison_SearchParamMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.SearchParamMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.LocationMessage> __Marshaller_prison_LocationMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.LocationMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.LocationArrayMessage> __Marshaller_prison_LocationArrayMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.LocationArrayMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.WorkerMessage> __Marshaller_prison_WorkerMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.WorkerMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.WorkerArrayMessage> __Marshaller_prison_WorkerArrayMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.WorkerArrayMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.JobMessage> __Marshaller_prison_JobMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.JobMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.JobArrayMessage> __Marshaller_prison_JobArrayMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.JobArrayMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.AccessReqMessage> __Marshaller_prison_AccessReqMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.AccessReqMessage.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PrisonService.AccessReplyMessage> __Marshaller_prison_AccessReplyMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PrisonService.AccessReplyMessage.Parser.ParseFrom);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::PrisonService.PrisonerMessage> __Method_GetPrisonerByID = new grpc::Method<global::PrisonService.IdMessage, global::PrisonService.PrisonerMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPrisonerByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_prison_PrisonerMessage);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.PrisonerArrayMessage> __Method_GetAllPrisoners = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.PrisonerArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllPrisoners",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_prison_PrisonerArrayMessage);

    static readonly grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.PrisonerArrayMessage> __Method_GetPrisonersByName = new grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.PrisonerArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetPrisonersByName",
        __Marshaller_prison_SearchParamMessage,
        __Marshaller_prison_PrisonerArrayMessage);

    static readonly grpc::Method<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddPrisoner = new grpc::Method<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddPrisoner",
        __Marshaller_prison_PrisonerMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdatePrisoner = new grpc::Method<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdatePrisoner",
        __Marshaller_prison_PrisonerMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeletePrisonerByID = new grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeletePrisonerByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::PrisonService.LocationMessage> __Method_GetLocationByID = new grpc::Method<global::PrisonService.IdMessage, global::PrisonService.LocationMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLocationByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_prison_LocationMessage);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.LocationArrayMessage> __Method_GetAllLocations = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.LocationArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllLocations",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_prison_LocationArrayMessage);

    static readonly grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.LocationArrayMessage> __Method_GetLocationsByName = new grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.LocationArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLocationsByName",
        __Marshaller_prison_SearchParamMessage,
        __Marshaller_prison_LocationArrayMessage);

    static readonly grpc::Method<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddLocation = new grpc::Method<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddLocation",
        __Marshaller_prison_LocationMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateLocation = new grpc::Method<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateLocation",
        __Marshaller_prison_LocationMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteLocationByID = new grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteLocationByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::PrisonService.WorkerMessage> __Method_GetWorkerByID = new grpc::Method<global::PrisonService.IdMessage, global::PrisonService.WorkerMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetWorkerByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_prison_WorkerMessage);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.WorkerArrayMessage> __Method_GetAllWorkers = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.WorkerArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllWorkers",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_prison_WorkerArrayMessage);

    static readonly grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.WorkerArrayMessage> __Method_GetWorkersByName = new grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.WorkerArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetWorkersByName",
        __Marshaller_prison_SearchParamMessage,
        __Marshaller_prison_WorkerArrayMessage);

    static readonly grpc::Method<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddWorker = new grpc::Method<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddWorker",
        __Marshaller_prison_WorkerMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateWorker = new grpc::Method<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateWorker",
        __Marshaller_prison_WorkerMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteWorkerByID = new grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteWorkerByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::PrisonService.JobMessage> __Method_GetJobByID = new grpc::Method<global::PrisonService.IdMessage, global::PrisonService.JobMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetJobByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_prison_JobMessage);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.JobArrayMessage> __Method_GetAllJobs = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.JobArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllJobs",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_prison_JobArrayMessage);

    static readonly grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.JobArrayMessage> __Method_GetJobsByName = new grpc::Method<global::PrisonService.SearchParamMessage, global::PrisonService.JobArrayMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetJobsByName",
        __Marshaller_prison_SearchParamMessage,
        __Marshaller_prison_JobArrayMessage);

    static readonly grpc::Method<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddJob = new grpc::Method<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddJob",
        __Marshaller_prison_JobMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateJob = new grpc::Method<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateJob",
        __Marshaller_prison_JobMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteJobByID = new grpc::Method<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteJobByID",
        __Marshaller_prison_IdMessage,
        __Marshaller_google_protobuf_Empty);

    static readonly grpc::Method<global::PrisonService.AccessReqMessage, global::PrisonService.AccessReplyMessage> __Method_AccessRequest = new grpc::Method<global::PrisonService.AccessReqMessage, global::PrisonService.AccessReplyMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AccessRequest",
        __Marshaller_prison_AccessReqMessage,
        __Marshaller_prison_AccessReplyMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PrisonService.PrisonReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PrisonSrv</summary>
    [grpc::BindServiceMethod(typeof(PrisonSrv), "BindService")]
    public abstract partial class PrisonSrvBase
    {
      public virtual global::System.Threading.Tasks.Task<global::PrisonService.PrisonerMessage> GetPrisonerByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.PrisonerArrayMessage> GetAllPrisoners(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.PrisonerArrayMessage> GetPrisonersByName(global::PrisonService.SearchParamMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddPrisoner(global::PrisonService.PrisonerMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdatePrisoner(global::PrisonService.PrisonerMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeletePrisonerByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.LocationMessage> GetLocationByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.LocationArrayMessage> GetAllLocations(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.LocationArrayMessage> GetLocationsByName(global::PrisonService.SearchParamMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddLocation(global::PrisonService.LocationMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateLocation(global::PrisonService.LocationMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteLocationByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.WorkerMessage> GetWorkerByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.WorkerArrayMessage> GetAllWorkers(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.WorkerArrayMessage> GetWorkersByName(global::PrisonService.SearchParamMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddWorker(global::PrisonService.WorkerMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateWorker(global::PrisonService.WorkerMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteWorkerByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.JobMessage> GetJobByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.JobArrayMessage> GetAllJobs(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.JobArrayMessage> GetJobsByName(global::PrisonService.SearchParamMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddJob(global::PrisonService.JobMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateJob(global::PrisonService.JobMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteJobByID(global::PrisonService.IdMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::PrisonService.AccessReplyMessage> AccessRequest(global::PrisonService.AccessReqMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PrisonSrvBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetPrisonerByID, serviceImpl.GetPrisonerByID)
          .AddMethod(__Method_GetAllPrisoners, serviceImpl.GetAllPrisoners)
          .AddMethod(__Method_GetPrisonersByName, serviceImpl.GetPrisonersByName)
          .AddMethod(__Method_AddPrisoner, serviceImpl.AddPrisoner)
          .AddMethod(__Method_UpdatePrisoner, serviceImpl.UpdatePrisoner)
          .AddMethod(__Method_DeletePrisonerByID, serviceImpl.DeletePrisonerByID)
          .AddMethod(__Method_GetLocationByID, serviceImpl.GetLocationByID)
          .AddMethod(__Method_GetAllLocations, serviceImpl.GetAllLocations)
          .AddMethod(__Method_GetLocationsByName, serviceImpl.GetLocationsByName)
          .AddMethod(__Method_AddLocation, serviceImpl.AddLocation)
          .AddMethod(__Method_UpdateLocation, serviceImpl.UpdateLocation)
          .AddMethod(__Method_DeleteLocationByID, serviceImpl.DeleteLocationByID)
          .AddMethod(__Method_GetWorkerByID, serviceImpl.GetWorkerByID)
          .AddMethod(__Method_GetAllWorkers, serviceImpl.GetAllWorkers)
          .AddMethod(__Method_GetWorkersByName, serviceImpl.GetWorkersByName)
          .AddMethod(__Method_AddWorker, serviceImpl.AddWorker)
          .AddMethod(__Method_UpdateWorker, serviceImpl.UpdateWorker)
          .AddMethod(__Method_DeleteWorkerByID, serviceImpl.DeleteWorkerByID)
          .AddMethod(__Method_GetJobByID, serviceImpl.GetJobByID)
          .AddMethod(__Method_GetAllJobs, serviceImpl.GetAllJobs)
          .AddMethod(__Method_GetJobsByName, serviceImpl.GetJobsByName)
          .AddMethod(__Method_AddJob, serviceImpl.AddJob)
          .AddMethod(__Method_UpdateJob, serviceImpl.UpdateJob)
          .AddMethod(__Method_DeleteJobByID, serviceImpl.DeleteJobByID)
          .AddMethod(__Method_AccessRequest, serviceImpl.AccessRequest).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PrisonSrvBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetPrisonerByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::PrisonService.PrisonerMessage>(serviceImpl.GetPrisonerByID));
      serviceBinder.AddMethod(__Method_GetAllPrisoners, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.PrisonerArrayMessage>(serviceImpl.GetAllPrisoners));
      serviceBinder.AddMethod(__Method_GetPrisonersByName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.SearchParamMessage, global::PrisonService.PrisonerArrayMessage>(serviceImpl.GetPrisonersByName));
      serviceBinder.AddMethod(__Method_AddPrisoner, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddPrisoner));
      serviceBinder.AddMethod(__Method_UpdatePrisoner, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.PrisonerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdatePrisoner));
      serviceBinder.AddMethod(__Method_DeletePrisonerByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeletePrisonerByID));
      serviceBinder.AddMethod(__Method_GetLocationByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::PrisonService.LocationMessage>(serviceImpl.GetLocationByID));
      serviceBinder.AddMethod(__Method_GetAllLocations, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.LocationArrayMessage>(serviceImpl.GetAllLocations));
      serviceBinder.AddMethod(__Method_GetLocationsByName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.SearchParamMessage, global::PrisonService.LocationArrayMessage>(serviceImpl.GetLocationsByName));
      serviceBinder.AddMethod(__Method_AddLocation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddLocation));
      serviceBinder.AddMethod(__Method_UpdateLocation, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.LocationMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateLocation));
      serviceBinder.AddMethod(__Method_DeleteLocationByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteLocationByID));
      serviceBinder.AddMethod(__Method_GetWorkerByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::PrisonService.WorkerMessage>(serviceImpl.GetWorkerByID));
      serviceBinder.AddMethod(__Method_GetAllWorkers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.WorkerArrayMessage>(serviceImpl.GetAllWorkers));
      serviceBinder.AddMethod(__Method_GetWorkersByName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.SearchParamMessage, global::PrisonService.WorkerArrayMessage>(serviceImpl.GetWorkersByName));
      serviceBinder.AddMethod(__Method_AddWorker, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddWorker));
      serviceBinder.AddMethod(__Method_UpdateWorker, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.WorkerMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateWorker));
      serviceBinder.AddMethod(__Method_DeleteWorkerByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteWorkerByID));
      serviceBinder.AddMethod(__Method_GetJobByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::PrisonService.JobMessage>(serviceImpl.GetJobByID));
      serviceBinder.AddMethod(__Method_GetAllJobs, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::PrisonService.JobArrayMessage>(serviceImpl.GetAllJobs));
      serviceBinder.AddMethod(__Method_GetJobsByName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.SearchParamMessage, global::PrisonService.JobArrayMessage>(serviceImpl.GetJobsByName));
      serviceBinder.AddMethod(__Method_AddJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddJob));
      serviceBinder.AddMethod(__Method_UpdateJob, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.JobMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateJob));
      serviceBinder.AddMethod(__Method_DeleteJobByID, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.IdMessage, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteJobByID));
      serviceBinder.AddMethod(__Method_AccessRequest, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PrisonService.AccessReqMessage, global::PrisonService.AccessReplyMessage>(serviceImpl.AccessRequest));
    }

  }
}
#endregion
