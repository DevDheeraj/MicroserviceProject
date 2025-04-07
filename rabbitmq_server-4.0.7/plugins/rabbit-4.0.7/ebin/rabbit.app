{application, 'rabbit', [
	{description, "RabbitMQ"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['amqqueue','background_gc','code_server_cache','gatherer','gm','internal_user','lqueue','mc','mc_amqp','mc_amqpl','mc_compat','mc_util','mirrored_supervisor','mirrored_supervisor_sups','pg_local','pid_recomposition','rabbit','rabbit_access_control','rabbit_alarm','rabbit_amqp1_0','rabbit_amqp_management','rabbit_amqp_reader','rabbit_amqp_session','rabbit_amqp_session_sup','rabbit_amqp_util','rabbit_amqp_writer','rabbit_amqqueue','rabbit_amqqueue_control','rabbit_amqqueue_process','rabbit_amqqueue_sup','rabbit_amqqueue_sup_sup','rabbit_auth_backend_internal','rabbit_auth_mechanism_amqplain','rabbit_auth_mechanism_anonymous','rabbit_auth_mechanism_cr_demo','rabbit_auth_mechanism_plain','rabbit_autoheal','rabbit_backing_queue','rabbit_basic','rabbit_binding','rabbit_boot_steps','rabbit_channel','rabbit_channel_interceptor','rabbit_channel_sup','rabbit_channel_sup_sup','rabbit_channel_tracking','rabbit_channel_tracking_handler','rabbit_classic_queue','rabbit_classic_queue_index_v2','rabbit_classic_queue_store_v2','rabbit_client_sup','rabbit_config','rabbit_confirms','rabbit_connection_helper_sup','rabbit_connection_sup','rabbit_connection_tracking','rabbit_connection_tracking_handler','rabbit_control_pbe','rabbit_core_ff','rabbit_core_metrics_gc','rabbit_credential_validation','rabbit_credential_validator','rabbit_credential_validator_accept_everything','rabbit_credential_validator_min_password_length','rabbit_credential_validator_password_regexp','rabbit_cuttlefish','rabbit_db','rabbit_db_binding','rabbit_db_binding_m2k_converter','rabbit_db_cluster','rabbit_db_exchange','rabbit_db_exchange_m2k_converter','rabbit_db_m2k_converter','rabbit_db_maintenance','rabbit_db_maintenance_m2k_converter','rabbit_db_msup','rabbit_db_msup_m2k_converter','rabbit_db_policy','rabbit_db_queue','rabbit_db_queue_m2k_converter','rabbit_db_rtparams','rabbit_db_rtparams_m2k_converter','rabbit_db_topic_exchange','rabbit_db_user','rabbit_db_user_m2k_converter','rabbit_db_vhost','rabbit_db_vhost_defaults','rabbit_db_vhost_m2k_converter','rabbit_dead_letter','rabbit_definitions','rabbit_definitions_hashing','rabbit_definitions_import_https','rabbit_definitions_import_local_filesystem','rabbit_depr_ff_extra','rabbit_deprecated_features','rabbit_diagnostics','rabbit_direct','rabbit_direct_reply_to','rabbit_disk_monitor','rabbit_epmd_monitor','rabbit_event_consumer','rabbit_exchange','rabbit_exchange_decorator','rabbit_exchange_parameters','rabbit_exchange_type','rabbit_exchange_type_direct','rabbit_exchange_type_fanout','rabbit_exchange_type_headers','rabbit_exchange_type_invalid','rabbit_exchange_type_local_random','rabbit_exchange_type_topic','rabbit_feature_flags','rabbit_ff_controller','rabbit_ff_extra','rabbit_ff_registry','rabbit_ff_registry_factory','rabbit_ff_registry_wrapper','rabbit_fhc_helpers','rabbit_fifo','rabbit_fifo_client','rabbit_fifo_dlx','rabbit_fifo_dlx_client','rabbit_fifo_dlx_sup','rabbit_fifo_dlx_worker','rabbit_fifo_index','rabbit_fifo_q','rabbit_fifo_v0','rabbit_fifo_v1','rabbit_fifo_v3','rabbit_file','rabbit_global_counters','rabbit_guid','rabbit_health_check','rabbit_khepri','rabbit_limiter','rabbit_log_channel','rabbit_log_connection','rabbit_log_mirroring','rabbit_log_prelaunch','rabbit_log_queue','rabbit_log_tail','rabbit_logger_exchange_h','rabbit_maintenance','rabbit_message_interceptor','rabbit_metrics','rabbit_mirror_queue_misc','rabbit_mnesia','rabbit_msg_store','rabbit_msg_store_gc','rabbit_networking','rabbit_networking_store','rabbit_node_monitor','rabbit_nodes','rabbit_observer_cli','rabbit_observer_cli_classic_queues','rabbit_observer_cli_quorum_queues','rabbit_osiris_metrics','rabbit_parameter_validation','rabbit_peer_discovery','rabbit_peer_discovery_classic_config','rabbit_peer_discovery_dns','rabbit_plugins','rabbit_policies','rabbit_policy','rabbit_policy_merge_strategy','rabbit_prelaunch_cluster','rabbit_prelaunch_enabled_plugins_file','rabbit_prelaunch_feature_flags','rabbit_prelaunch_logging','rabbit_priority_queue','rabbit_process','rabbit_process_flag','rabbit_queue_consumers','rabbit_queue_decorator','rabbit_queue_index','rabbit_queue_location','rabbit_queue_type','rabbit_queue_type_util','rabbit_quorum_memory_manager','rabbit_quorum_queue','rabbit_quorum_queue_periodic_membership_reconciliation','rabbit_ra_registry','rabbit_ra_systems','rabbit_reader','rabbit_recovery_terms','rabbit_release_series','rabbit_restartable_sup','rabbit_router','rabbit_runtime_parameters','rabbit_ssl','rabbit_stream_coordinator','rabbit_stream_queue','rabbit_stream_sac_coordinator','rabbit_sup','rabbit_sysmon_handler','rabbit_sysmon_minder','rabbit_table','rabbit_time_travel_dbg','rabbit_trace','rabbit_tracking','rabbit_tracking_store','rabbit_upgrade_preparation','rabbit_uri','rabbit_variable_queue','rabbit_version','rabbit_vhost','rabbit_vhost_limit','rabbit_vhost_msg_store','rabbit_vhost_process','rabbit_vhost_sup','rabbit_vhost_sup_sup','rabbit_vhost_sup_wrapper','rabbit_vhosts','rabbit_vm','supervised_lifecycle','tcp_listener','tcp_listener_sup','term_to_binary_compat','vhost']},
	{registered, [rabbit_sup,rabbit_amqqueue_sup,rabbit_direct_client_sup,rabbit_log,rabbit_node_monitor,rabbit_router]},
	{applications, [kernel,stdlib,sasl,os_mon,inets,compiler,public_key,crypto,ssl,syntax_tools,xmerl,ranch,rabbit_common,amqp10_common,rabbitmq_prelaunch,ra,sysmon_handler,stdout_formatter,recon,redbug,observer_cli,osiris,syslog,systemd,seshat,horus,khepri,khepri_mnesia_migration,cuttlefish,gen_batch_server]},
	{optional_applications, []},
	{mod, {rabbit, []}},
	{env, [
	    {tcp_listeners, [5672]},
	    {num_tcp_acceptors, 10},
	    {ssl_listeners, []},
	    {num_ssl_acceptors, 10},
	    {ssl_options, []},
	    {vm_memory_high_watermark, 0.6},
	    {vm_memory_calculation_strategy, rss},
	    {disk_free_limit, 50000000}, %% 50MB
	    {backing_queue_module, rabbit_variable_queue},
	    %% 0 ("no limit") would make a better default, but that
	    %% breaks the QPid Java client
	    {frame_max, 131072},
	    %% see rabbitmq-server#1593
	    {channel_max, 2047},
	    {session_max_per_connection, 64},
	    {link_max_per_session, 256},
	    {ranch_connection_max, infinity},
	    {heartbeat, 60},
	    {msg_store_file_size_limit, 16777216},
	    {msg_store_shutdown_timeout, 600000},
	    {fhc_write_buffering, true},
	    {fhc_read_buffering, false},
	    {queue_index_max_journal_entries, 32768},
	    {queue_index_embed_msgs_below, 4096},
	    {default_user, <<"guest">>},
	    {default_pass, <<"guest">>},
	    {default_user_tags, [administrator]},
	    {default_vhost, <<"/">>},
	    {default_permissions, [<<".*">>, <<".*">>, <<".*">>]},
	    {loopback_users, [<<"guest">>]},
	    {password_hashing_module, rabbit_password_hashing_sha256},
	    {server_properties, []},
	    {collect_statistics, none},
	    {collect_statistics_interval, 5000},
	    {mnesia_table_loading_retry_timeout, 30000},
	    {mnesia_table_loading_retry_limit, 10},
	    %% The identity to act as for anonymous logins.
	    {anonymous_login_user, <<"guest">>},
	    {anonymous_login_pass, <<"guest">>},
	    %% "The server mechanisms are ordered in decreasing level of preference."
	    %% AMQP §5.3.3.1
	    {auth_mechanisms, ['PLAIN', 'AMQPLAIN', 'ANONYMOUS']},
	    {auth_backends, [rabbit_auth_backend_internal]},
	    {delegate_count, 16},
	    {trace_vhosts, []},
	    {ssl_cert_login_from, distinguished_name},
	    {ssl_handshake_timeout, 5000},
	    {ssl_allow_poodle_attack, false},
	    {handshake_timeout, 10000},
	    {reverse_dns_lookups, false},
	    {cluster_partition_handling, ignore},
	    {cluster_keepalive_interval, 10000},
	    {autoheal_state_transition_timeout, 60000},
	    {tcp_listen_options, [{backlog,       128},
	                          {nodelay,       true},
	                          {linger,        {true, 0}},
	                          {exit_on_close, false}
	                         ]},
	    {ssl_apps, [asn1, crypto, public_key, ssl]},
	    %% see rabbitmq-server#114
            {classic_queue_flow_control, true},
	    %% see rabbitmq-server#227 and related tickets.
	    %% msg_store_credit_disc_bound only takes effect when
	    %% messages are persisted to the message store. If messages
	    %% are embedded on the queue index, then modifying this
	    %% setting has no effect because credit_flow is not used when
	    %% writing to the queue index. See the setting
	    %% queue_index_embed_msgs_below above.
	    {msg_store_credit_disc_bound, {4000, 800}},
	    %% see rabbitmq-server#143,
	    %% rabbitmq-server#949, rabbitmq-server#1098
	    {credit_flow_default_credit, {400, 200}},
	    {quorum_commands_soft_limit, 32},
	    {quorum_cluster_size, 3},
	    %% see rabbitmq-server#248
	    %% and rabbitmq-server#667
	    {channel_operation_timeout, 15000},
	    %% See https://www.rabbitmq.com/docs/consumers#acknowledgement-timeout
	    %% 30 minutes
	    {consumer_timeout, 1800000},

	    %% used by rabbit_peer_discovery_classic_config
	    {cluster_nodes, {[], disc}},

	    {config_entry_decoder, [{passphrase, undefined}]},
	    {background_gc_enabled, false},
	    {background_gc_target_interval, 60000},
	    %% rabbitmq-server#589
	    {proxy_protocol, false},
	    {disk_monitor_failure_retries, 10},
	    {disk_monitor_failure_retry_interval, 120000},
	    %% either "stop_node" or "continue".
	    %% by default we choose to not terminate the entire node if one
	    %% vhost had to shut down, see server#1158 and server#1280
	    {vhost_restart_strategy, continue},
	    %% {global, prefetch count}
	    {default_consumer_prefetch, {false, 0}},
		  %% interval at which the channel can perform periodic actions
	    {channel_tick_interval, 60000},
	    %% Default max message size is 16 MB
	    {max_message_size, 16777216},
	    %% Socket writer will run GC every 1 GB of outgoing data
	    {writer_gc_threshold, 1000000000},
	    %% interval at which connection/channel tracking executes post operations
	    {tracking_execution_timeout, 15000},
	    {stream_messages_soft_limit, 256},
      	{track_auth_attempt_source, false},
		{credentials_obfuscation_fallback_secret, <<"nocookie">>},
      	{dead_letter_worker_consumer_prefetch, 32},
      	{dead_letter_worker_publisher_confirm_timeout, 180000},
		{vhost_process_reconciliation_run_interval, 30},
		%% for testing
		{vhost_process_reconciliation_enabled, true},
		{license_line, "Licensed under the MPL 2.0. Website: https://rabbitmq.com"}
	  ]}
]}.