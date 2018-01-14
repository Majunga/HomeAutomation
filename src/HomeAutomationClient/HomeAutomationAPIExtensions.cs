// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace HomeAutomationClient
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for HomeAutomationAPI.
    /// </summary>
    public static partial class HomeAutomationAPIExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void AccountLogoutPost(this IHomeAutomationAPI operations)
            {
                operations.AccountLogoutPostAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AccountLogoutPostAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.AccountLogoutPostWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<DeviceEntity> ApiDeviceGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiDeviceGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<DeviceEntity>> ApiDeviceGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Posts Device to server
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceEntity'>
            /// </param>
            public static DeviceEntity ApiDevicePost(this IHomeAutomationAPI operations, DeviceEntity deviceEntity = default(DeviceEntity))
            {
                return operations.ApiDevicePostAsync(deviceEntity).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Posts Device to server
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceEntity> ApiDevicePostAsync(this IHomeAutomationAPI operations, DeviceEntity deviceEntity = default(DeviceEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDevicePostWithHttpMessagesAsync(deviceEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static DeviceEntity ApiDeviceByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiDeviceByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceEntity> ApiDeviceByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceEntity'>
            /// </param>
            public static void ApiDeviceByIdPut(this IHomeAutomationAPI operations, int id, DeviceEntity deviceEntity = default(DeviceEntity))
            {
                operations.ApiDeviceByIdPutAsync(id, deviceEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceByIdPutAsync(this IHomeAutomationAPI operations, int id, DeviceEntity deviceEntity = default(DeviceEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceByIdPutWithHttpMessagesAsync(id, deviceEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiDeviceByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiDeviceByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<DeviceSensorEntity> ApiDeviceSensorGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiDeviceSensorGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<DeviceSensorEntity>> ApiDeviceSensorGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceSensorGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceSensorEntity'>
            /// </param>
            public static DeviceSensorEntity ApiDeviceSensorPost(this IHomeAutomationAPI operations, DeviceSensorEntity deviceSensorEntity = default(DeviceSensorEntity))
            {
                return operations.ApiDeviceSensorPostAsync(deviceSensorEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceSensorEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceSensorEntity> ApiDeviceSensorPostAsync(this IHomeAutomationAPI operations, DeviceSensorEntity deviceSensorEntity = default(DeviceSensorEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceSensorPostWithHttpMessagesAsync(deviceSensorEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static DeviceSensorEntity ApiDeviceSensorByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiDeviceSensorByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceSensorEntity> ApiDeviceSensorByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceSensorByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceSensorEntity'>
            /// </param>
            public static void ApiDeviceSensorByIdPut(this IHomeAutomationAPI operations, int id, DeviceSensorEntity deviceSensorEntity = default(DeviceSensorEntity))
            {
                operations.ApiDeviceSensorByIdPutAsync(id, deviceSensorEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceSensorEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceSensorByIdPutAsync(this IHomeAutomationAPI operations, int id, DeviceSensorEntity deviceSensorEntity = default(DeviceSensorEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceSensorByIdPutWithHttpMessagesAsync(id, deviceSensorEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiDeviceSensorByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiDeviceSensorByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceSensorByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceSensorByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<DeviceTypeEntity> ApiDeviceTypeGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiDeviceTypeGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<DeviceTypeEntity>> ApiDeviceTypeGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceTypeGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceTypeEntity'>
            /// </param>
            public static DeviceTypeEntity ApiDeviceTypePost(this IHomeAutomationAPI operations, DeviceTypeEntity deviceTypeEntity = default(DeviceTypeEntity))
            {
                return operations.ApiDeviceTypePostAsync(deviceTypeEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceTypeEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceTypeEntity> ApiDeviceTypePostAsync(this IHomeAutomationAPI operations, DeviceTypeEntity deviceTypeEntity = default(DeviceTypeEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceTypePostWithHttpMessagesAsync(deviceTypeEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static DeviceTypeEntity ApiDeviceTypeByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiDeviceTypeByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DeviceTypeEntity> ApiDeviceTypeByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiDeviceTypeByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceTypeEntity'>
            /// </param>
            public static void ApiDeviceTypeByIdPut(this IHomeAutomationAPI operations, int id, DeviceTypeEntity deviceTypeEntity = default(DeviceTypeEntity))
            {
                operations.ApiDeviceTypeByIdPutAsync(id, deviceTypeEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='deviceTypeEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceTypeByIdPutAsync(this IHomeAutomationAPI operations, int id, DeviceTypeEntity deviceTypeEntity = default(DeviceTypeEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceTypeByIdPutWithHttpMessagesAsync(id, deviceTypeEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiDeviceTypeByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiDeviceTypeByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiDeviceTypeByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiDeviceTypeByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<LocationEntity> ApiLocationGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiLocationGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<LocationEntity>> ApiLocationGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiLocationGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='locationEntity'>
            /// </param>
            public static LocationEntity ApiLocationPost(this IHomeAutomationAPI operations, LocationEntity locationEntity = default(LocationEntity))
            {
                return operations.ApiLocationPostAsync(locationEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='locationEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LocationEntity> ApiLocationPostAsync(this IHomeAutomationAPI operations, LocationEntity locationEntity = default(LocationEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiLocationPostWithHttpMessagesAsync(locationEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static LocationEntity ApiLocationByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiLocationByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LocationEntity> ApiLocationByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiLocationByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='locationEntity'>
            /// </param>
            public static void ApiLocationByIdPut(this IHomeAutomationAPI operations, int id, LocationEntity locationEntity = default(LocationEntity))
            {
                operations.ApiLocationByIdPutAsync(id, locationEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='locationEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiLocationByIdPutAsync(this IHomeAutomationAPI operations, int id, LocationEntity locationEntity = default(LocationEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiLocationByIdPutWithHttpMessagesAsync(id, locationEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiLocationByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiLocationByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiLocationByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiLocationByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<SensorEntity> ApiSensorGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiSensorGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<SensorEntity>> ApiSensorGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSensorGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='sensorEntity'>
            /// </param>
            public static SensorEntity ApiSensorPost(this IHomeAutomationAPI operations, SensorEntity sensorEntity = default(SensorEntity))
            {
                return operations.ApiSensorPostAsync(sensorEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='sensorEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SensorEntity> ApiSensorPostAsync(this IHomeAutomationAPI operations, SensorEntity sensorEntity = default(SensorEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSensorPostWithHttpMessagesAsync(sensorEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static SensorEntity ApiSensorByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiSensorByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SensorEntity> ApiSensorByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSensorByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='sensorEntity'>
            /// </param>
            public static void ApiSensorByIdPut(this IHomeAutomationAPI operations, int id, SensorEntity sensorEntity = default(SensorEntity))
            {
                operations.ApiSensorByIdPutAsync(id, sensorEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='sensorEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSensorByIdPutAsync(this IHomeAutomationAPI operations, int id, SensorEntity sensorEntity = default(SensorEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiSensorByIdPutWithHttpMessagesAsync(id, sensorEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiSensorByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiSensorByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSensorByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiSensorByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<SettingEntity> ApiSettingGet(this IHomeAutomationAPI operations)
            {
                return operations.ApiSettingGetAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<SettingEntity>> ApiSettingGetAsync(this IHomeAutomationAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSettingGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='settingEntity'>
            /// </param>
            public static SettingEntity ApiSettingPost(this IHomeAutomationAPI operations, SettingEntity settingEntity = default(SettingEntity))
            {
                return operations.ApiSettingPostAsync(settingEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='settingEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SettingEntity> ApiSettingPostAsync(this IHomeAutomationAPI operations, SettingEntity settingEntity = default(SettingEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSettingPostWithHttpMessagesAsync(settingEntity, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static SettingEntity ApiSettingByIdGet(this IHomeAutomationAPI operations, int id)
            {
                return operations.ApiSettingByIdGetAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SettingEntity> ApiSettingByIdGetAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSettingByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='settingEntity'>
            /// </param>
            public static void ApiSettingByIdPut(this IHomeAutomationAPI operations, int id, SettingEntity settingEntity = default(SettingEntity))
            {
                operations.ApiSettingByIdPutAsync(id, settingEntity).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='settingEntity'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSettingByIdPutAsync(this IHomeAutomationAPI operations, int id, SettingEntity settingEntity = default(SettingEntity), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiSettingByIdPutWithHttpMessagesAsync(id, settingEntity, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiSettingByIdDelete(this IHomeAutomationAPI operations, int id)
            {
                operations.ApiSettingByIdDeleteAsync(id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSettingByIdDeleteAsync(this IHomeAutomationAPI operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiSettingByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
