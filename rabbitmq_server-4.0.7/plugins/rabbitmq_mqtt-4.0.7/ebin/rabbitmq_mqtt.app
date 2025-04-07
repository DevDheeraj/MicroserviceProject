{application, 'rabbitmq_mqtt', [
	{description, "RabbitMQ MQTT Adapter"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['Elixir.RabbitMQ.CLI.Ctl.Commands.ListMqttConnectionsCommand','mc_mqtt','rabbit_mqtt','rabbit_mqtt_confirms','rabbit_mqtt_ff','rabbit_mqtt_internal_event_handler','rabbit_mqtt_keepalive','rabbit_mqtt_packet','rabbit_mqtt_processor','rabbit_mqtt_qos0_queue','rabbit_mqtt_reader','rabbit_mqtt_retained_msg_store','rabbit_mqtt_retained_msg_store_dets','rabbit_mqtt_retained_msg_store_ets','rabbit_mqtt_retained_msg_store_noop','rabbit_mqtt_retainer','rabbit_mqtt_retainer_sup','rabbit_mqtt_sup','rabbit_mqtt_util']},
	{registered, [rabbitmq_mqtt_sup]},
	{applications, [kernel,stdlib,ssl,ranch,rabbit,amqp10_common]},
	{optional_applications, []},
	{mod, {rabbit_mqtt, []}},
	{env, [
	    {ssl_cert_login,false},
	    {allow_anonymous, true},
	    {vhost, <<"/">>},
	    {exchange, <<"amq.topic">>},
	    {max_session_expiry_interval_seconds, 86400}, %% 1 day
	    {retained_message_store, rabbit_mqtt_retained_msg_store_dets},
	    %% only used by DETS store
	    {retained_message_store_dets_sync_interval, 2000},
	    {prefetch, 10},
	    {ssl_listeners, []},
	    {tcp_listeners, [1883]},
	    {num_tcp_acceptors, 10},
	    {num_ssl_acceptors, 10},
	    {tcp_listen_options, [{backlog,   128},
	                          {nodelay,   true},
	                          {send_timeout, 15000},
	                          {send_timeout_close, true}
	                         ]},
	    {proxy_protocol, false},
	    {sparkplug, false},
	    {mailbox_soft_limit, 200},
	    {max_packet_size_unauthenticated, 65536},
	    %% 256 MB is upper limit defined by MQTT spec
	    {max_packet_size_authenticated, 268435455},
	    {topic_alias_maximum, 16}
	  ]},
		{broker_version_requirements, []}
]}.